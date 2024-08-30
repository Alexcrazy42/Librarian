namespace Domain.Contracts.Requests.Rents;

public class CreateClassRentEdBookRequest
{
    public Guid ClassSubjectId { get; set; }

    public Guid ClassSubjectChapterId { get; set; }
}
