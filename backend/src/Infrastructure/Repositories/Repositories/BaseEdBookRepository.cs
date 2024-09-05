using Domain.Contracts.Requests.EdBooks;
using Domain.Entities.Books;
using Domain.Interfaces.Repositories;
using Store.Db;

namespace Repositories.Repositories;

internal class BaseEdBookRepository : IBaseEdBookRepository
{
    private readonly LibraryDbContext libraryDbContext;

    public BaseEdBookRepository(LibraryDbContext libraryDbContext)
    {
        this.libraryDbContext = libraryDbContext;
    }

    public Task<Guid> CreateBookAfterUserSureWhatAnotherVariantsNotSuitAsync(CreateBaseEdBookRequest request, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<BaseEducationalBook>> GetOrCreateBaseEdBookAsync(CreateBaseEdBookRequest request, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
