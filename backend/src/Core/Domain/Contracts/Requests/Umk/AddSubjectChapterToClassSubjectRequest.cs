namespace Domain.Contracts.Requests.Umk;

public class AddSubjectChapterToClassSubjectRequest
{
    public Guid ClassSubjectId { get; set; }

    public string Title { get; set; }
}
