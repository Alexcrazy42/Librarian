using Domain.HelpingEntities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Store.Db;

namespace Repositories.Repositories.Helping;

internal class BookAuthorRepository : IBookAuthorRepository
{
    private readonly LibraryDbContext libraryDbContext;

    public BookAuthorRepository(LibraryDbContext libraryDbContext)
    {
        this.libraryDbContext = libraryDbContext;
    }

    public async Task<BookAuthor> CreateBookAuthorIfNotExistsAsync(string fullName, CancellationToken ct)
    {
        var bookAuthor = await libraryDbContext.BookAuthors
            .FirstOrDefaultAsync(x => x.FullName.ToUpper() == fullName.ToUpper(), ct);

        if (bookAuthor == null)
        {
            var newBookAuthor = new BookAuthor(Guid.NewGuid(), fullName);

            libraryDbContext.BookAuthors.Add(newBookAuthor);
            await libraryDbContext.SaveChangesAsync(ct);

            return newBookAuthor;
        }

        return bookAuthor;
    }

    public async Task<IReadOnlyCollection<BookAuthor>> GetBookAuthorsAsync(string partName, CancellationToken ct)
    {
        return await libraryDbContext.BookAuthors
            .Where(x => x.FullName.ToUpper().Contains(partName.ToUpper()))
            .ToListAsync(ct);
    }
}
