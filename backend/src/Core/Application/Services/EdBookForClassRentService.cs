using Domain.Common.Exceptions;
using Domain.Entities.Books;
using Domain.Entities.Rents.People;
using Domain.Entities.SchoolStructure;
using Domain.Entities.Subjects;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Application.Services;

internal class EdBookForClassRentService : IEdBookForClassRentService
{
    private readonly IClassRepository classRepository;
    private readonly IClassSubjectRepository classSubjectRepository;
    private readonly IEdBookForClassRentRepository edBookForClassRentRepository;

    public EdBookForClassRentService(IClassRepository classRepository,
        IClassSubjectRepository classSubjectRepository,
        IEdBookForClassRentRepository edBookForClassRentRepository)
    {
        this.classRepository = classRepository;
        this.classSubjectRepository = classSubjectRepository;
        this.edBookForClassRentRepository = edBookForClassRentRepository;
    }

    public async Task<IReadOnlyCollection<EducationalBookStudentRent>> IssueEdBooksToClassBySubjectChapterAsync(Guid classId, Guid subjectChapterId, 
        DateOnly rentUntil, CancellationToken ct)
    {
        var classWithStudentsAndClassSubjectChapters = await classRepository.GetSchoolClassWithStudentsAndClassSubjectsChaptersAsync(classId, ct);
        
        if (!IsClassHasThisSubjectChapter(subjectChapterId, classWithStudentsAndClassSubjectChapters))
        {
            throw new CommonException("У данного класса нет такой части предмета!");
        }

        var students = classWithStudentsAndClassSubjectChapters.Students;

        var classSubjectChapterEdBookWithDetails = await classSubjectRepository.GetSubjectChapterWithEdBooksAsync(subjectChapterId, ct);

        var edBooksInBalance = classSubjectChapterEdBookWithDetails.EdBooks
            .Select(x => x.EdBookInBalance).ToList();
        var edBooksTotalCount = edBooksInBalance.Sum(x => x.TotalCount);

        var maxRentCount = int.Min(students.Count, edBooksTotalCount);

        var edBookStudentRents = new List<EducationalBookStudentRent>();

        for (int i = 0; i < maxRentCount; i++)
        {
            var edBookIndex = GetEdBookIndexWhatCanGive(edBooksInBalance);
            
            // TODO: избавиться от continue
            if (edBookIndex == -1)
            {
                continue;
            }

            var student = students[i];

            var edBookStudentRent = new EducationalBookStudentRent(
                id: Guid.NewGuid(),
                student: student,
                book: edBooksInBalance[edBookIndex],
                count: 1,
                isArchived: false,
                isOverdue: false,
                startDate: DateOnly.FromDateTime(DateTime.Now),
                endDate: rentUntil
            );

            student.AddEdBookRent(edBookStudentRent);
            edBooksInBalance[edBookIndex].DecreaseInPlaceCount();
            edBookStudentRents.Add(edBookStudentRent);
        }

        return await edBookForClassRentRepository.CreateEdBooksStudentsRentsAsync(edBookStudentRents, ct);
    }

    private bool IsClassHasThisSubjectChapter(Guid subjectChapterId, SchoolClass schoolClass)
    {

        foreach (var classSubject in schoolClass.ClassSubjects)
        {

            foreach (var chapter in classSubject.Chapters)
            {
                if (chapter.Id == subjectChapterId)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private int GetEdBookIndexWhatCanGive(IList<EducationalBookInBalance> edBooks)
    {
        for (int i = 0; i < edBooks.Count; i++)
        {
            if (edBooks[i].InPlaceCount > 0)
            {
                return i;
            }
        }

        return -1;
    }
}
