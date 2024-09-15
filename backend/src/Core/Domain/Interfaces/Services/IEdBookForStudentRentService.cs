using Domain.Contracts.Requests.Rents.Students;

namespace Domain.Interfaces.Services;

public interface IEdBookForStudentRentService
{
    public Task<string> IssueEdBookToStudentAsync(StudentEdBookRentRequest request, CancellationToken ct);

    public Task<string> ReturnEdBookFromStudentAsync(IReadOnlyCollection<ReturnEdBookFromStudentRequest> requests, CancellationToken ct);
}
