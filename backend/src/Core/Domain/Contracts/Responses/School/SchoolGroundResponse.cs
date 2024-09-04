namespace Domain.Contracts.Responses.School;

public class SchoolGroundResponse
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public Guid SchoolId { get; set; }

    public IReadOnlyCollection<SchoolClassWithoutManagerResponse> Classes { get; set; } = new List<SchoolClassWithoutManagerResponse>();

    public IReadOnlyCollection<LibrarianResponse> Librarians { get; set; } = new List<LibrarianResponse>();

    public SchoolGroundResponse(Guid id,
        string name,
        Guid schoolId)
    {
        Id = id;
        Name = name;
        SchoolId = schoolId;
    }
}
