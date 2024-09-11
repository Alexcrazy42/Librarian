using Domain.Common.Exceptions;
using Domain.Entities.Supplies;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Store.Db;

namespace Repositories.Repositories;

internal class SupplyRepository : ISupplyRepository
{
    public readonly LibraryDbContext libraryDbContext;

    public SupplyRepository(LibraryDbContext libraryDbContext)
    {
        this.libraryDbContext = libraryDbContext;
    }

    public async Task<Guid> CreateBookSupplyAndGetIdAsync(BookSupply supply, CancellationToken ct)
    {
        libraryDbContext.BookSupplies.Add(supply);

        await libraryDbContext.SaveChangesAsync();

        return supply.Id;
    }

    public async Task EndFillingSupplyAsync(Guid supplyId, CancellationToken ct)
    {
        var supply = await libraryDbContext.BookSupplies
            .FirstOrDefaultAsync(x => x.Id == supplyId, ct)
            ?? throw new NotFoundException("Поставка не найдена!");

        supply.EndFilling();

        await libraryDbContext.SaveChangesAsync();
    }

    public async Task<BookSupply> GetBookSupplyAsync(Guid id, CancellationToken ct)
    {
        return await libraryDbContext.BookSupplies
            .Include(x => x.EdBooks)
                .ThenInclude(edBook => edBook.BaseEducationalBook)
             .Include(x => x.EdBooks)
                .ThenInclude(edBook => edBook.CurrentSchoolGround)
            .FirstOrDefaultAsync(x => x.Id == id, ct)
            ?? throw new NotFoundException("Поставка не найдена!");
    }
}
