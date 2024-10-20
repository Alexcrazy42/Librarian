namespace Domain.Contracts.Requests.Umk;

public class AddSubjectToUmkClassRequest
{
    public Guid UmkClassId { get; set; }

    public Guid SubjectId { get; set; }
}
