using Domain.Entities.Supplies;

namespace Domain.Interfaces.Repositories;

public interface ISupplyRepository
{
    public Task<BookSupply> GetBookSupplyAsync(Guid id, CancellationToken ct);

    public Task<IReadOnlyCollection<BookSupply>> GetNotFillfilledSuppliesAsync(Guid groundId, CancellationToken ct);

    public Task<Guid> CreateBookSupplyAndGetIdAsync(BookSupply supply, CancellationToken ct);

    public Task EndFillingSupplyAsync(Guid supplyId, CancellationToken ct);
}
