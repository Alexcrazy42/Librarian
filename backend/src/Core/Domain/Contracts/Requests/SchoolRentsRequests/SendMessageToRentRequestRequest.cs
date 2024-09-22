using Domain.Enums;

namespace Domain.Contracts.Requests.SchoolRentsRequests;

public class SendMessageToRentRequestRequest
{
    public Guid RentRequestId { get; set; }

    public Guid GroundSenderId { get; set; }

    public string Message { get; set; }

    public SchoolRentConversationMessageStatus Status { get; set; }

    public int? ReadyGiveBookCount { get; set; }

    public DateOnly? ReadyEndRentAt { get; set; }
}