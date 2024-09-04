using Domain.Entities.Supplies;

namespace Domain.Interfaces.Repositories;

public interface ISupplyRepository
{
    public Task<BookSupply> GetBookSupplyAsync(Guid id, CancellationToken ct);

    public Task<Guid> CreateBookSupplyAndGetIdAsync(BookSupply supply, CancellationToken ct);
}
