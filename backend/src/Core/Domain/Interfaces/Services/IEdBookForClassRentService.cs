using Domain.Entities.Rents.People;

namespace Domain.Interfaces.Services;

public interface IEdBookForClassRentService
{
    public Task<IReadOnlyCollection<EducationalBookStudentRent>> IssueEdBooksToClassBySubjectChapterAsync(
        Guid classId, Guid subjectChapterId, DateOnly rentUntil, CancellationToken ct);
}
