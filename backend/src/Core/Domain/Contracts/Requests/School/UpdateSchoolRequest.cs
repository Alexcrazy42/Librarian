using Domain.Common;

namespace Domain.Contracts.Requests.School;

public record UpdateSchoolRequest(Guid Id, string ShortName, string OfficialName);

public record UpdateSchoolGroundRequest(Guid Id, string Name);

public class UpdateLibrarianRequest : Person
{
    public Guid Id { get; set; }

    public bool IsGeneral { get; set; }
}