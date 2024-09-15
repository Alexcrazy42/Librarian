using Domain.Common.Exceptions;
using Domain.Entities.Rents.People;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Store.Db;

namespace Repositories.Repositories;

internal class EdBookForEmployeeRentRepository : IEdBookForEmployeeRentRepository
{
    private readonly LibraryDbContext libraryDbContext;

    public EdBookForEmployeeRentRepository(LibraryDbContext libraryDbContext)
    {
        this.libraryDbContext = libraryDbContext;
    }

    public async Task<EducationalBookEmployeeRent> CreateEmployeeEdBookRentAsync(EducationalBookEmployeeRent rent, CancellationToken ct)
    {
        libraryDbContext.Attach(rent.Book);
        libraryDbContext.EdBookEmployeeRents.Add(rent);

        await libraryDbContext.SaveChangesAsync(ct);

        return rent;
    }

    public async Task<EducationalBookEmployeeRent> GetEmployeeEdBookRentAsync(Guid employeeId, Guid edBookInBalanceId, CancellationToken ct)
    {
        return await libraryDbContext.EdBookEmployeeRents
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Employee.Id == employeeId
                && x.Book.Id == edBookInBalanceId, ct)
            ?? throw new NotFoundException("Не найдена аренда!");
    }

    public async Task<IReadOnlyCollection<EducationalBookEmployeeRent>> GetEmployeeEdBookRentsAsync(Guid employeeId, CancellationToken ct)
    {
        return await libraryDbContext.EdBookEmployeeRents
            .Where(x => x.Employee.Id == employeeId)
            .ToListAsync(ct);
    }

    public async Task<IReadOnlyCollection<EducationalBookEmployeeRent>> GetEmployeeEdBookRentsWithEmployeeAndBookAsync(IReadOnlyCollection<Guid> ids, CancellationToken ct)
    {
        return await libraryDbContext.EdBookEmployeeRents
            .Include(x => x.Employee)
            .Include(x => x.Book)
            .Where(x => ids.Contains(x.Id))
            .ToListAsync(ct);
    }

    public async Task<EducationalBookEmployeeRent> UpdateEmployeeEdBookRentAsync(EducationalBookEmployeeRent rent, CancellationToken ct)
    {
        libraryDbContext.Entry(rent).State = EntityState.Modified;

        await libraryDbContext.SaveChangesAsync(ct);

        return rent;
    }

    public async Task<IReadOnlyCollection<EducationalBookEmployeeRent>> UpdateEmployeeEdBookRentsAsync(IReadOnlyCollection<EducationalBookEmployeeRent> rents, CancellationToken ct)
    {
        libraryDbContext.AttachRange(rents);

        await libraryDbContext.SaveChangesAsync(ct);

        return await libraryDbContext.EdBookEmployeeRents
            .Where(x => rents.Select(x => x.Id).ToList().Contains(x.Id))
            .ToListAsync(ct);
    }
}
