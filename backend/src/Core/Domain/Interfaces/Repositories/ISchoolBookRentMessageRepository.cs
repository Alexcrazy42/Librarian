
namespace Domain.Interfaces.Repositories;

public interface ISchoolBookRentMessageRepository
{
    public Task VisibleMessagesAsync(IReadOnlyCollection<Guid> messageIds, CancellationToken ct);
}
