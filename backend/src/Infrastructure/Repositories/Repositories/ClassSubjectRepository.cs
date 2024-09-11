using Domain.Common.Exceptions;
using Domain.Entities.Subjects;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Store.Db;

namespace Repositories.Repositories;

internal class ClassSubjectRepository : IClassSubjectRepository
{
    private readonly LibraryDbContext libraryDbContext;

    public ClassSubjectRepository(LibraryDbContext libraryDbContext)
    {
        this.libraryDbContext = libraryDbContext;
    }

    public async Task<IReadOnlyCollection<ClassSubject>> CreateClassSubjectStructureAsync(IReadOnlyCollection<ClassSubject> classSubjects, CancellationToken ct)
    {
        libraryDbContext.ClassSubjects
            .AddRange(classSubjects);

        await libraryDbContext.SaveChangesAsync();

        return classSubjects;
    }

    public async Task<ClassSubjectChapter> GetSubjectChapterWithEdBooksAsync(Guid chapterId, CancellationToken ct)
    {
        return await libraryDbContext.ClassSubjectChapters
            .Include(x => x.EdBooks)
                .ThenInclude(edBook => edBook.EdBookInBalance)
            .FirstOrDefaultAsync(x => x.Id == chapterId, ct)
            ?? throw new NotFoundException("Такая часть предмета не найдена!");
    }

    public async Task<IReadOnlyCollection<ClassSubjectChapterEdBook>> SetEdBookToSubjectChaptersAsync(
        IReadOnlyCollection<ClassSubjectChapterEdBook> classSubjectChapterEdBooks, CancellationToken ct)
    {
        foreach (var i in classSubjectChapterEdBooks)
        {
            libraryDbContext.Attach(i.EdBookInBalance);
            libraryDbContext.Attach(i.SubjectChapter);
        }

        libraryDbContext.ClassSubjectChapterEdBooks.AddRange(classSubjectChapterEdBooks);

        await libraryDbContext.SaveChangesAsync(ct);

        foreach (var i in classSubjectChapterEdBooks)
        {
            libraryDbContext.Entry(i.EdBookInBalance).State = EntityState.Detached;
            libraryDbContext.Entry(i.SubjectChapter).State = EntityState.Detached;
        }


        return await libraryDbContext.ClassSubjectChapterEdBooks
            .Include(x => x.SubjectChapter)
            .Include(x => x.EdBookInBalance)
                .ThenInclude(edBookInBalance => edBookInBalance.BaseEducationalBook)
            .Where(x => classSubjectChapterEdBooks.Select(x => x.Id).Contains(x.Id))
            .ToListAsync(ct);
    }
}
