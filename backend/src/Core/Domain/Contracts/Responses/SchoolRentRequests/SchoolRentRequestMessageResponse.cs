using Domain.Enums;

namespace Domain.Contracts.Responses.SchoolRentRequests;

public class SchoolRentRequestMessageResponse
{
    public Guid Id { get; set; }

    public Guid SenderId { get; set; }

    public string Message { get; set; }

    public DateTime CreatedAt { get; set; }

    public SchoolRentConversationMessageStatus Status { get; set; }

    public bool ViewedByReceiver { get; set; }
}