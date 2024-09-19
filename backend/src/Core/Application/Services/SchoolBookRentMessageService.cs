using Domain.Interfaces.Services;

namespace Application.Services;

internal class SchoolBookRentMessageService : ISchoolBookRentMessageService
{
    public Task<bool> CanSendMessageToChatAsync(Guid requestId, Guid senderId, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
