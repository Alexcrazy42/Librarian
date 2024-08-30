using Domain.Entities.SchoolStructure;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
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

    public async Task<School> GetById(Guid schoolId, CancellationToken cancellationToken)
    {
        var school = await libraryDbContext.Schools
            .AsNoTracking()
            .Include(x => x.Grounds)
                .ThenInclude(x => x.Classes)
            .Include(x => x.Grounds)
                .ThenInclude(x => x.Librarians)
            .FirstOrDefaultAsync(x => x.Id == schoolId, cancellationToken);

        return school;
    }
}
