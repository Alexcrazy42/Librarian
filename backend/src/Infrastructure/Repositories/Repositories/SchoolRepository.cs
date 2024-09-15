using Domain.Common.Exceptions;
using Domain.Contracts.Requests.School;
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
        await libraryDbContext.Schools.AddAsync(school, ct);

        return school;
    }

    public async Task<School> GetById(Guid schoolId, CancellationToken ct)
    {
        return await libraryDbContext.Schools
            .AsNoTracking()
            .Include(x => x.Grounds)
                .ThenInclude(x => x.Classes)
            .Include(x => x.Grounds)
                .ThenInclude(x => x.Librarians)
            .FirstOrDefaultAsync(x => x.Id == schoolId, ct)
            ?? throw new NotFoundException("Школа не найдена!");
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

    public async Task<SchoolGround> UpdateGroundAsync(UpdateSchoolGroundRequest request, CancellationToken ct)
    {
        var ground = await libraryDbContext.SchoolGrounds
            .FirstOrDefaultAsync(x => x.Id == request.Id, ct)
            ?? throw new NotFoundException("Площадка не найдена!");

        ground.Name = request.Name;

        libraryDbContext.Entry(ground).State = EntityState.Modified;

        await libraryDbContext.SaveChangesAsync(ct);

        return ground;
    }

    public async Task<Librarian> UpdateLibrarianAsync(UpdateLibrarianRequest request, CancellationToken ct)
    {
        var librarian = await libraryDbContext.Librarians
            .FirstOrDefaultAsync(x => x.Id == request.Id, ct)
            ?? throw new NotFoundException("Библиотекарь не найден!");

        librarian.Surname = request.Surname;
        librarian.Name = request.Name;
        librarian.Patronymic = request.Patronymic;
        librarian.IsGeneral = request.IsGeneral;

        libraryDbContext.Entry(librarian).State = EntityState.Modified;

        await libraryDbContext.SaveChangesAsync(ct);

        return librarian;
    }

    public async Task<School> UpdateSchoolAsync(UpdateSchoolRequest request, CancellationToken ct)
    {
        var school = await libraryDbContext.Schools
            .FirstOrDefaultAsync(x => x.Id == request.Id, ct)
            ?? throw new NotFoundException("Школа не найдена!");

        school.OfficialName = request.OfficialName;
        school.ShortName = request.ShortName;

        libraryDbContext.Entry(school).State = EntityState.Modified;
        await libraryDbContext.SaveChangesAsync(ct);
        return school;
    }
}
