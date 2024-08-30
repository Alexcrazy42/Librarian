namespace Domain.Contracts.Responses;

public class SchoolResponse
{
    public Guid Id { get; private set; }

    public string ShortName { get; private set; }

    public string OfficialName { get; private set; }

    public IReadOnlyCollection<SchoolGroundResponse> Grounds { get; set; } = new List<SchoolGroundResponse>();

    public SchoolResponse(Guid id, 
        string shortName, 
        string officialName)
    {
        Id = id;
        ShortName = shortName;
        OfficialName = officialName;
    }
}
