namespace Domain.Contracts.Responses.School;

public class LibrarianResponse
{
    public Guid Id { get; private set; }

    public Guid GroundId { get; private set; }

    public Guid SchoolId { get; private set; }

    public bool IsGeneral { get; private set; }

    public LibrarianResponse(Guid id,
        Guid groundId,
        Guid schoolId,
        bool isGeneral)
    {
        Id = id;
        GroundId = groundId;
        SchoolId = schoolId;
        IsGeneral = isGeneral;
    }
}
