namespace Domain.Contracts.Requests.SchoolRentsRequests;

public class SendMessageToRentRequestResponseRequest
{
    public Guid RentRequestId { get; set; }

    public Guid GroundSenderId { get; set; }

    public string Message { get; set; }

    public int? ChangeRequestedBookCount { get; set; }
}