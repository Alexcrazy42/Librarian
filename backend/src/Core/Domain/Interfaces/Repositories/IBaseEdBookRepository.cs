using Domain.Contracts.Requests.EdBooks;
using Domain.Entities.Books;

namespace Domain.Interfaces.Repositories;

public interface IBaseEdBookRepository
{
    public Task<IReadOnlyCollection<BaseEducationalBook>> GetSimilarBookAsync(GetSimilarBaseEdBookRequest request, CancellationToken ct);

    public Task<Guid> CreateBookAfterUserSureWhatAnotherVariantsNotSuitAsync(CreateBaseEdBookRequest request, CancellationToken ct);
}
