using Domain.Entities.Rents.People;
using Domain.Interfaces.Repositories;
using Store.Db;

namespace Repositories.Repositories;

internal class EdBookForClassRentRepository : IEdBookForClassRentRepository
{
    private readonly LibraryDbContext libraryDbContext;

    public EdBookForClassRentRepository(LibraryDbContext libraryDbContext)
    {
        this.libraryDbContext = libraryDbContext;
    }

    public async Task<IReadOnlyCollection<EducationalBookStudentRent>> CreateEdBooksStudentsRentsAsync(IReadOnlyCollection<EducationalBookStudentRent> edBooksStudentsRents, CancellationToken ct)
    {
        libraryDbContext.EdBooksStudentsRents.AddRange(edBooksStudentsRents);

        await libraryDbContext.SaveChangesAsync(ct);

        return edBooksStudentsRents;
    }
}
