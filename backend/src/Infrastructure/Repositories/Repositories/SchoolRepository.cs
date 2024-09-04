using Domain.Common.Exceptions;
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

    public async Task<School> CreateSchoolStructureAsync(School school, CancellationToken ct)
    {
        libraryDbContext.Schools.Add(school);

        await libraryDbContext.SaveChangesAsync(ct);
        return school;
    }

    public async Task<School> GetById(Guid schoolId, CancellationToken ct)
    {
        var school = await libraryDbContext.Schools
            .AsNoTracking()
            .Include(x => x.Grounds)
                .ThenInclude(x => x.Classes)
            .Include(x => x.Grounds)
                .ThenInclude(x => x.Librarians)
            .FirstOrDefaultAsync(x => x.Id == schoolId, ct);

        return school;
    }

    public async Task<SchoolGround> GetGroundWithClassesById(Guid groundId, CancellationToken ct)
    {
        return await libraryDbContext.SchoolGrounds
            .Include(x => x.Classes)
            .FirstOrDefaultAsync(x => x.Id == groundId, ct)
            ?? throw new NotFoundException("Не найдена площадка!");
    }

    public async Task<(School School, SchoolGround SchoolGround)> GetSchoolAndGroundByGroundId(Guid groundId, CancellationToken ct)
    {
        var schoolGround = await libraryDbContext.SchoolGrounds
            .Include(x => x.School)
            .FirstOrDefaultAsync(x => x.Id == groundId, ct)
            ?? throw new NotFoundException("Площадка не найдена!");

        return (schoolGround.School, schoolGround);
    }
}
