using Domain.Entities.Subjects;

namespace Domain.Interfaces.Repositories;

public interface IClassSubjectRepository
{
    public Task<IReadOnlyCollection<ClassSubject>> CreateClassSubjectStructureAsync(IReadOnlyCollection<ClassSubject> classSubjects, CancellationToken ct);

    public Task<IReadOnlyCollection<ClassSubjectChapterEdBook>> SetEdBookToSubjectChaptersAsync(IReadOnlyCollection<ClassSubjectChapterEdBook> classSubjectChapterEdBooks, CancellationToken ct);

    public Task<ClassSubjectChapter> GetSubjectChapterWithEdBooksAsync(Guid chapterId, CancellationToken ct);
}
