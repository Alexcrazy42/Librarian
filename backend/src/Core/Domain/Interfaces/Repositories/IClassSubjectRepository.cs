using Domain.Contracts.Requests.ClassSubjects;
using Domain.Entities.Subjects;

namespace Domain.Interfaces.Repositories;

public interface IClassSubjectRepository
{
    public Task<IReadOnlyCollection<ClassSubject>> GetClassSubjectStructureForClassAsync(Guid classId, CancellationToken ct);

    public Task<IReadOnlyCollection<ClassSubject>> CreateClassSubjectStructureAsync(IReadOnlyCollection<ClassSubject> classSubjects, CancellationToken ct);

    public Task<IReadOnlyCollection<ClassSubjectChapterEdBook>> SetEdBookToSubjectChaptersAsync(IReadOnlyCollection<ClassSubjectChapterEdBook> classSubjectChapterEdBooks, CancellationToken ct);

    public Task<ClassSubjectChapter> GetSubjectChapterWithEdBooksAsync(Guid chapterId, CancellationToken ct);

    public Task<IReadOnlyCollection<ClassSubject>> UpdateClassSubjectsAsync(IReadOnlyCollection<UpdateClassSubjectRequest> requests, CancellationToken ct);

    public Task<IReadOnlyCollection<ClassSubjectChapter>> UpdateClassSubjectChaptersAsync(IReadOnlyCollection<UpdateSubjectChapterRequest> requests, CancellationToken ct);

    public Task<IReadOnlyCollection<ClassSubjectChapterEdBook>> UpdateSubjectChapterEdBookAsync(IReadOnlyCollection<UpdateSubjectChapterEdBookRequest> requests, CancellationToken ct);
}
