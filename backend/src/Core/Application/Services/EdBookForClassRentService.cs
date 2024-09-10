using Domain.Common.Exceptions;
using Domain.Entities.Rents.People;
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

    public async Task<IReadOnlyCollection<EducationalBookStudentRent>> IssueEdBooksToClassBySubjectChapterAsync(Guid classId, Guid subjectChapterId, CancellationToken ct)
    {
        // TODO: проверка на то, что у этого класса ведется такой предмет

        var classWithStudents = await classRepository.GetSchoolClassWithStudentsAsync(classId, ct);
        var students = classWithStudents.Students;

        var classSubjectChapterEdBookWithDetails = await classSubjectRepository.GetSubjectChapterEdBookWithDetailsAsync(subjectChapterId, ct);
        var edBookInBalance = classSubjectChapterEdBookWithDetails.EdBookInBalance
            ?? throw new NotFoundException("Не задана книга для части предмета!");

        var maxRentCount = int.Min(students.Count, edBookInBalance.TotalCount);

        var edBookStudentRents = new List<EducationalBookStudentRent>();

        for (int i = 0; i < maxRentCount; i++)
        {
            var student = students[i];

            var edBookStudentRent = new EducationalBookStudentRent(
                id: Guid.NewGuid(),
                student: student,
                book: edBookInBalance,
                count: 1,
                startDate: DateOnly.FromDateTime(DateTime.Now),
                endDate: DateOnly.FromDateTime(DateTime.Now).AddDays(14)
            );

            edBookStudentRents.Add(edBookStudentRent);

            student.AddEdBookRent(edBookStudentRent);

            edBookInBalance.DecreaseInPlaceCount();
        }

        return await edBookForClassRentRepository.CreateEdBooksStudentsRentsAsync(edBookStudentRents, ct);
    }
}
