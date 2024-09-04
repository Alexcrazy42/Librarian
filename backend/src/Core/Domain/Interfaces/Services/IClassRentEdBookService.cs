using Domain.Contracts.Requests.Rents;

namespace Domain.Interfaces.Services;

public interface IClassRentEdBookService
{
    public Task<string> CreateClassRentEdBooksAsync(CreateClassRentEdBookRequest request, CancellationToken ct);
}
