using Domain.Entities.SchoolStructure;
using Domain.Interfaces.Repositories;
using Store.Db;

namespace Repositories.Repositories;

internal class SchoolRepository : ISchoolRepository
{
    private readonly LibraryDbContext libraryDbContext;

    public SchoolRepository(LibraryDbContext libraryDbContext)
    {
        this.libraryDbContext = libraryDbContext;
    }

    public async Task<School> CreateSchoolStructureAsync(School school, CancellationToken cancellationToken)
    {
        libraryDbContext.Schools.Add(school);

        await libraryDbContext.SaveChangesAsync(cancellationToken);
        return school;
    }
}
