namespace Domain.Contracts.Requests.Umk;

public class DeleteEdBookInBalanceFromChapterRequest
{
    public Guid ChapterId { get; set; }

    public Guid EdBookInBalanceId { get; set; }
}
