using Domain.Contracts.Requests.Supplies;
using Domain.Entities.Supplies;

namespace Domain.Interfaces.Services;

public interface ISupplyService
{
    public Task<Guid> CreateSupplyAsync(CreateBookSupplyRequest request, CancellationToken ct);
}
