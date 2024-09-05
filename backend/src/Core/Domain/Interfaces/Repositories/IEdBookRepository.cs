using Domain.Contracts.Requests.EdBooks;
using Domain.Entities.Books;

namespace Domain.Interfaces.Repositories;

public interface IEdBookRepository
{
    public Task<EducationalBookInBalance> CreateEdBookAsync(CreateEdBookRequest request, CancellationToken ct);
}
