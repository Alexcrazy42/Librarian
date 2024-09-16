using Domain.Contracts.Requests.EdBooks;
using Domain.Entities.Books;

namespace Domain.Interfaces.Repositories;

public interface IEdBookInBalanceRepository
{
    public Task<EducationalBookInBalance> GetEdBookInBalanceAsync(Guid id, CancellationToken ct);

    public Task<EducationalBookInBalance> CreateEdBookInBalanceAsync(CreateEdBookInBalanceRequest request, CancellationToken ct);

    public Task<EducationalBookInBalance> UpdateEdBookInBalanceAsync(EducationalBookInBalance edBookInBalance, CancellationToken ct);

    public Task<IReadOnlyCollection<EducationalBookInBalance>> GetEdBooksInBalanceByBaseEdBookIdAsync(Guid baseEdBookId, CancellationToken ct);
}
