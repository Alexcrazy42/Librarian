namespace Domain.Contracts.Requests.ClassSubjects;

public class SetEdBookToClassSubjectChapterRequest
{
    public Guid ClassSubjectChapterId { get; set; }

    public Guid EdBookInBalanceId { get; set; }
}
