using Domain.Contracts.Requests.EdBooks;
using Domain.Contracts.Requests.SchoolRentsRequests;
using Domain.Contracts.Responses.SchoolRentRequests;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("api/school-rents")]
public class SchoolBookRentController : ControllerBase
{
    [HttpGet("schools-with-needed-book")]
    public async Task<IReadOnlyCollection<SchoolGroundWithEdBookResponse>> GetSchoolsHaveFamiliarEdBookAsync([FromBody] GetSimilarBaseEdBookRequest request, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task CreateSchoolRentRequestAsync([FromBody] CreateSchoolRentRequest request, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
