using Domain.Contracts.Requests.Rents.Students;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("api/ed-book-student-rent")]
public class EdBookForStudentRentController : ControllerBase
{
    private readonly IEdBookForStudentRentService edBookForStudentRentService;

    public EdBookForStudentRentController(IEdBookForStudentRentService edBookForStudentRentService)
    {
        this.edBookForStudentRentService = edBookForStudentRentService;
    }

    [HttpPost("issue-ed-book-to-student")]
    public async Task<string> IssueEdBookToStudentAsync(StudentEdBookRentRequest request, CancellationToken ct)
    {
        return await edBookForStudentRentService.IssueEdBookToStudentAsync(request, ct);
    }

    [HttpDelete("return-book")]
    public async Task<string> ReturnEdBookFromStudentAsync([FromBody] IReadOnlyCollection<ReturnEdBookFromStudentRequest> requests, CancellationToken ct)
    {
        return await edBookForStudentRentService.ReturnEdBookFromStudentAsync(requests, ct);
    }
}
