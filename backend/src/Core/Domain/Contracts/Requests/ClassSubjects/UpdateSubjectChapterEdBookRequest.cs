namespace Domain.Contracts.Requests.ClassSubjects;

public class UpdateSubjectChapterEdBookRequest
{
    public Guid Id { get; set; }

    public Guid EdBookInBalanceId { get; set; }
}
