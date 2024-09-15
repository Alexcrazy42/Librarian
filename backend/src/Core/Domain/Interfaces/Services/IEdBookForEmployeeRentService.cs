using Domain.Contracts.Requests.Rents.Employees;

namespace Domain.Interfaces.Services;

public interface IEdBookForEmployeeRentService
{
    public Task<string> IssueEdBookToEmployeeAsync(EmployeeEdBookRentRequest request, CancellationToken ct);

    public Task<string> ReturnEdBookFromEmployeeAsync(IReadOnlyCollection<ReturnEdBookFromEmployeeRequest> requests, CancellationToken ct);
}