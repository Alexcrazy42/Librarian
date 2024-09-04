using Domain.Contracts.Requests.Students;
using Domain.Entities.SchoolStructure;

namespace Domain.Interfaces.Services;

public interface IStudentService
{
    public Task<IReadOnlyCollection<Student>> AddStudentsToClassAsync(AddStudentsToClassRequest request, CancellationToken ct);
}
