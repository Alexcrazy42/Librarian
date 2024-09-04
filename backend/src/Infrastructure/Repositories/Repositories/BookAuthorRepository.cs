using Domain.Common.Exceptions;
using Domain.HelpingEntities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Store.Db;

namespace Repositories.Repositories;

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
            .FirstOrDefaultAsync(x => x.FullName == fullName, ct);

        if (bookAuthor == null)
        {
            var newBookAuthor = new BookAuthor(Guid.NewGuid(), fullName);

            await libraryDbContext.BookAuthors.AddAsync(newBookAuthor, ct);

            return newBookAuthor;
        }

        return bookAuthor;
    }

    public Task<IReadOnlyCollection<BookAuthor>> GetBookAuthorsAsync(string partName, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
