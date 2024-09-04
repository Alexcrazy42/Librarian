using Domain.Contracts.Requests.ClassSubjects;
using Domain.Entities.Subjects;
using Domain.HelpingEntities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System.Linq;

namespace Application.Services;

internal class ClassSubjectService : IClassSubjectService
{
    private readonly ISchoolRepository schoolRepository;
    private readonly ISubjectRepository subjectRepository;
    private readonly IClassSubjectRepository classSubjectRepository;

    public ClassSubjectService(ISchoolRepository schoolRepository,
        ISubjectRepository subjectRepository,
        IClassSubjectRepository classSubjectRepository)
    {
        this.schoolRepository = schoolRepository;
        this.subjectRepository = subjectRepository;
        this.classSubjectRepository = classSubjectRepository;
    }

    public async Task<IReadOnlyCollection<ClassSubject>> CreateClassSubjectStructureAsync(CreateClassSubjectStructureRequest request, CancellationToken ct)
    {
        var ground = await schoolRepository.GetGroundWithClassesById(request.GroundId, ct);

        var createSubjectRequests = request.ClassSubjects
            .SelectMany(x => x.Subjects)
            .ToList();

        var subjects = await subjectRepository.GetOrCreateSubjectsAsync(createSubjectRequests, ct);

        var allClassSubjects = new List<ClassSubject>();

        foreach (var classSubject in request.ClassSubjects)
        { 
            var schoolClass = ground.Classes
                .FirstOrDefault(x => x.Id == classSubject.SchoolClassId);
            if (schoolClass == null)
            {
                continue;
            }

            var subjectsForThisClass = subjects.Where(
                    subject =>
                    classSubject.Subjects.Any(
                        x => 
                        (x.SubjectId.HasValue && x.SubjectId == subject.Id) ||
                        (x.SubjectName != null && x.SubjectName.Equals(subject.Name, StringComparison.OrdinalIgnoreCase))
                    ))
                .ToList();


            var classSubjects = subjectsForThisClass.Select(x => 
                new ClassSubject(
                    Guid.NewGuid(),
                    schoolClass,
                    x,
                    GetChaptersForClassSubject(request, schoolClass.Id, x.Id, x.Name)))
                .ToList();

            schoolClass.AddSubjects(classSubjects);
            allClassSubjects.AddRange(classSubjects);
        }

        return await classSubjectRepository.CreateClassSubjectStructureAsync(allClassSubjects, ct);
    }

    private List<ClassSubjectChapter> GetChaptersForClassSubject(CreateClassSubjectStructureRequest request, Guid classId, Guid? id, string? name)
    {
        var classSubjectChapters = new List<ClassSubjectChapter>();

        var classSubjects = request.ClassSubjects.Where(x => x.SchoolClassId == classId);

        foreach (var classSubject in classSubjects)
        {
            foreach (var subject in classSubject.Subjects)
            {
                if (subject.SubjectId.HasValue && subject.SubjectId == id ||
                    subject.SubjectName != null && subject.SubjectName.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    foreach (var subjectChapterName in subject.ChapterNames)
                    {
                        classSubjectChapters.Add(new ClassSubjectChapter(
                            id: Guid.NewGuid(),
                            title: subjectChapterName
                        ));
                    }

                }
            }
        }
        return classSubjectChapters;
    }
}
