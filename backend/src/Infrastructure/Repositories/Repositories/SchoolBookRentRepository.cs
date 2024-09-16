using Domain.Common.Exceptions;
using Domain.Entities.RentRequests;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Store.Db;

namespace Repositories.Repositories;

internal class SchoolBookRentRepository : ISchoolBookRentRepository
{
    private readonly LibraryDbContext libraryDbContext;

    public SchoolBookRentRepository(LibraryDbContext libraryDbContext)
    {
        this.libraryDbContext = libraryDbContext;
    }

    public async Task<EducationalBookSchoolRentRequest> CreateAsync(EducationalBookSchoolRentRequest entity, CancellationToken ct)
    {
        libraryDbContext.Attach(entity.DebtorSchoolGround);
        libraryDbContext.Attach(entity.OwnerSchoolGround);
        libraryDbContext.Attach(entity.CreatedBy);
        libraryDbContext.Attach(entity.Book);

        libraryDbContext.EdBookSchoolRentRequests.Add(entity);

        await libraryDbContext.SaveChangesAsync(ct);

        libraryDbContext.Entry(entity.DebtorSchoolGround).State = EntityState.Detached;
        libraryDbContext.Entry(entity.OwnerSchoolGround).State = EntityState.Detached;
        libraryDbContext.Entry(entity.CreatedBy).State = EntityState.Detached;
        libraryDbContext.Entry(entity.Book).State = EntityState.Detached;

        return await libraryDbContext.EdBookSchoolRentRequests
            .Include(x => x.DebtorSchoolGround)
            .Include(x => x.OwnerSchoolGround)
            .Include(x => x.Book)
            .Include(x => x.CreatedBy)
            .FirstOrDefaultAsync(x => x.Id == entity.Id, ct)
            ?? throw new NotFoundException("Запрос не найден!");
    }

    public async Task<IReadOnlyCollection<EducationalBookSchoolRentRequest>> GetAllReceivedRequestsAsync(Guid groundId, CancellationToken ct)
    {
        return await libraryDbContext.EdBookSchoolRentRequests
            .Include(x => x.DebtorSchoolGround)
            .Include(x => x.OwnerSchoolGround)
            .Include(x => x.Book)
            .Include(x => x.CreatedBy)
            .Where(x => x.OwnerSchoolGround.Id == groundId)
            .ToListAsync(ct);
    }

    public async Task<IReadOnlyCollection<EducationalBookSchoolRentRequest>> GetAllSendedRequests(Guid groundId, CancellationToken ct)
    {
        return await libraryDbContext.EdBookSchoolRentRequests
            .Include(x => x.DebtorSchoolGround)
            .Include(x => x.OwnerSchoolGround)
            .Include(x => x.Book)
            .Include(x => x.CreatedBy)
            .Where(x => x.DebtorSchoolGround.Id == groundId)
            .ToListAsync(ct);
    }

    public async Task<EducationalBookSchoolRentRequest> GetAsync(Guid id, CancellationToken ct)
    {
        return await libraryDbContext.EdBookSchoolRentRequests
            .Include(x => x.DebtorSchoolGround)
            .Include(x => x.OwnerSchoolGround)
            .Include(x => x.Book)
            .Include(x => x.CreatedBy)
            .FirstOrDefaultAsync(x => x.Id == id, ct)
            ?? throw new NotFoundException("Запрос не найден!");
    }
}
