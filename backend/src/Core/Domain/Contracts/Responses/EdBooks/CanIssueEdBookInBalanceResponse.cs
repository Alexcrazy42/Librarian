namespace Domain.Contracts.Responses.EdBooks;

public class CanIssueEdBookInBalanceResponse
{
    public bool Can { get; init; }

    public string? Message { get; init; }

    public CanIssueEdBookInBalanceResponse(bool can,
        string? message = "")
    {
        Can = can;
        Message = message;
    }
}
