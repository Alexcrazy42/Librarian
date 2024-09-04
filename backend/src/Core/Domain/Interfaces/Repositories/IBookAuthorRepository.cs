using Domain.HelpingEntities;

namespace Domain.Interfaces.Repositories;

public interface IBookAuthorRepository
{
    public Task<IReadOnlyCollection<BookAuthor>> GetBookAuthorsAsync(string partName, CancellationToken ct);

    public Task<BookAuthor> CreateBookAuthorIfNotExistsAsync(string fullName, CancellationToken ct);
}
