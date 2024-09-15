namespace Domain.Contracts.Requests.ClassSubjects;

public class UpdateClassSubjectRequest
{
    public Guid Id { get; set; }

    public Guid SubjectId { get; set; }
}
