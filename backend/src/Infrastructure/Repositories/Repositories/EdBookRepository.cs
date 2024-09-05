using Domain.Contracts.Requests.EdBooks;
using Domain.Entities.Books;
using Domain.Interfaces.Repositories;
using Store.Db;

namespace Repositories.Repositories;

internal class EdBookRepository : IEdBookRepository
{
    private readonly LibraryDbContext libraryDbContext;

    public EdBookRepository(LibraryDbContext libraryDbContext)
    {
        this.libraryDbContext = libraryDbContext;
    }

    public Task<EducationalBookInBalance> CreateEdBookAsync(CreateEdBookRequest request, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
