namespace Domain.Contracts.Requests.Umk;

public class AttachEdBooksInBalanceToChapterRequest
{
    public Guid ChapterId { get; set; }

    public IReadOnlyCollection<Guid> EdBookInBalanceIds { get; set; } = new List<Guid>();
}
