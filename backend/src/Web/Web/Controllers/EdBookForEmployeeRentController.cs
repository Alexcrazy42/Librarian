using Domain.Contracts.Requests.Rents.Employees;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("api/ed-book-for-employee")]
public class EdBookForEmployeeRentController : ControllerBase
{ 
    private readonly IEdBookForEmployeeRentService edBookForEmployeeRentService;

    public EdBookForEmployeeRentController(IEdBookForEmployeeRentService edBookForEmployeeRentService)
    {
        this.edBookForEmployeeRentService = edBookForEmployeeRentService;
    }

    [HttpPost("issue-ed-book-to-employee")]
    public async Task<string> IssueEdBookToEmployeeAsync(EmployeeEdBookRentRequest request, CancellationToken ct)
    {
        return await edBookForEmployeeRentService.IssueEdBookToEmployeeAsync(request, ct);
    }

    [HttpDelete("return-book")]
    public async Task<string> ReturnEdBookFromEmployeeAsync([FromBody] IReadOnlyCollection<ReturnEdBookFromEmployeeRequest> requests, CancellationToken ct)
    {
        return await edBookForEmployeeRentService.ReturnEdBookFromEmployeeAsync(requests, ct);
    }
}
