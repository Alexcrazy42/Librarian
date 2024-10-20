using Domain.Interfaces.Repositories;
using Store.Db;

namespace Repositories.Repositories;

internal class UmkRepository : IUmkRepository
{
    private readonly LibraryDbContext libraryDbContext;

    public UmkRepository(LibraryDbContext libraryDbContext)
    {
        this.libraryDbContext = libraryDbContext;
    }
}
