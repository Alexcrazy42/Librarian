using Domain.Common.Exceptions;
using Domain.Contracts.Requests.ClassSubjects;
using Domain.Contracts.Responses.EdBooks;
using Domain.Entities.Books;
using Domain.Entities.Subjects;
using Domain.HelpingEntities;
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

    public async Task<IReadOnlyCollection<ClassSubject>> GetClassSubjectStructureForClassAsync(Guid classId, CancellationToken ct)
    {
        return await libraryDbContext.ClassSubjects
            .Include(x => x.SchoolClass)
            .Include(x => x.Subject)    
            .Include(x => x.Chapters)
                .ThenInclude(chapter => chapter.EdBooks)
                    .ThenInclude(edBook => edBook.BaseEducationalBook)
                        // TODO
                        //.ThenInclude(edBookInBalance => edBookInBalance.BaseEducationalBook)
            .Where(x => x.SchoolClass.Id == classId)
            .ToListAsync(ct);
    }

    public async Task<ClassSubjectChapter> GetSubjectChapterWithEdBooksAsync(Guid chapterId, CancellationToken ct)
    {
        return await libraryDbContext.ClassSubjectChapters
            .Include(x => x.EdBooks)
                .ThenInclude(edBook => edBook.BaseEducationalBook)
            .FirstOrDefaultAsync(x => x.Id == chapterId, ct)
            ?? throw new NotFoundException("Такая часть предмета не найдена!");
    }

    public async Task<IReadOnlyCollection<ClassSubjectChapterEdBook>> SetEdBookToSubjectChaptersAsync(
        IReadOnlyCollection<ClassSubjectChapterEdBook> classSubjectChapterEdBooks, CancellationToken ct)
    {
        foreach (var i in classSubjectChapterEdBooks)
        {
            libraryDbContext.Attach(i.BaseEducationalBook);
            libraryDbContext.Attach(i.SubjectChapter);
        }

        libraryDbContext.ClassSubjectChapterEdBooks.AddRange(classSubjectChapterEdBooks);

        await libraryDbContext.SaveChangesAsync(ct);

        foreach (var i in classSubjectChapterEdBooks)
        {
            libraryDbContext.Entry(i.BaseEducationalBook).State = EntityState.Detached;
            libraryDbContext.Entry(i.SubjectChapter).State = EntityState.Detached;
        }


        return await libraryDbContext.ClassSubjectChapterEdBooks
            .Include(x => x.SubjectChapter)
            .Include(x => x.BaseEducationalBook)
                // TODO
                //.ThenInclude(edBookInBalance => edBookInBalance.BaseEducationalBook)
            .Where(x => classSubjectChapterEdBooks.Select(x => x.Id).Contains(x.Id))
            .ToListAsync(ct);
    }

    public async Task<IReadOnlyCollection<ClassSubjectChapter>> UpdateClassSubjectChaptersAsync(IReadOnlyCollection<UpdateSubjectChapterRequest> requests, CancellationToken ct)
    {
        foreach (var request in requests)
        {
            var classSubjectChapter = new ClassSubjectChapter(request.Id);
            classSubjectChapter.Title = request.Title;
            libraryDbContext.Entry(classSubjectChapter).State = EntityState.Modified;
        }

        await libraryDbContext.SaveChangesAsync(ct);

        return await libraryDbContext.ClassSubjectChapters
            .AsNoTracking()
            .Where(x => requests.Select(x => x.Id).ToList().Contains(x.Id))
            .ToListAsync(ct);
    }

    public async Task<IReadOnlyCollection<ClassSubject>> UpdateClassSubjectsAsync(IReadOnlyCollection<UpdateClassSubjectRequest> requests, CancellationToken ct)
    {
        var subjects = new List<Subject>();

        foreach (var request in requests)
        {
            var classSubject = new ClassSubject(request.Id);
            var subject = new Subject(request.SubjectId);
            libraryDbContext.Attach(classSubject);
            libraryDbContext.Attach(subject);

            subjects.Add(subject);

            classSubject.SetSubject(subject);
            libraryDbContext.Entry(classSubject).State = EntityState.Modified;
        }

        await libraryDbContext.SaveChangesAsync(ct);

        foreach (var subject in subjects)
        {
            libraryDbContext.Entry(subject).State = EntityState.Detached;
        }

        return await libraryDbContext.ClassSubjects
            .AsNoTracking()
            .Include(x => x.Subject)
            .Where(x => requests.Select(x => x.Id).ToList().Contains(x.Id))
            .ToListAsync(ct);
    }

    // TODO
    public async Task<IReadOnlyCollection<ClassSubjectChapterEdBook>> UpdateSubjectChapterEdBookAsync(IReadOnlyCollection<UpdateSubjectChapterEdBookRequest> requests, CancellationToken ct)
    {
        var baseEducationalBooks = new List<BaseEducationalBook>();

        foreach (var request in requests)
        {
            var classSubjectChapterEdBook = new ClassSubjectChapterEdBook(request.Id);
            var baseEdBook = new BaseEducationalBook(request.BaseEdBookId);
            baseEducationalBooks.Add(baseEdBook);
            
            classSubjectChapterEdBook.SetEdBookInBalance(baseEdBook);
            
            libraryDbContext.Entry(classSubjectChapterEdBook).State = EntityState.Modified;
            libraryDbContext.Attach(baseEdBook);

            
            libraryDbContext.Entry(classSubjectChapterEdBook).State = EntityState.Modified;
        }

        await libraryDbContext.SaveChangesAsync(ct);

        foreach (var edBook in baseEducationalBooks)
        {
            libraryDbContext.Entry(edBook).State = EntityState.Detached;
        }

        return await libraryDbContext.ClassSubjectChapterEdBooks
            .AsNoTracking()
            .Include(x => x.BaseEducationalBook)
                // TODO
                //.ThenInclude(edBook => edBook.BaseEducationalBook)
            .Where(x => requests.Select(x => x.Id).ToList().Contains(x.Id))
            .ToListAsync(ct);
    }
}
