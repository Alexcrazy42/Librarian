
namespace Domain.Interfaces.Services;

public interface ISchoolBookRentMessageService
{
    public Task<bool> CanSendMessageToChatAsync(Guid requestId, Guid senderId, CancellationToken ct);
}
