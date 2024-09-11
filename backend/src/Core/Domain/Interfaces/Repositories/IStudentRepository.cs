using Domain.Contracts.Requests.Students;
using Domain.Entities.SchoolStructure;

namespace Domain.Interfaces.Repositories;

public interface IStudentRepository
{
    public Task<IReadOnlyCollection<Student>> AddStudentsToClassAsync(IReadOnlyCollection<Student> students, CancellationToken ct);

    public Task<IReadOnlyCollection<Student>> GetStudentsFromClassAsync(Guid classId, CancellationToken ct);

    public Task TransferStudentsToYearUpAsync(IReadOnlyCollection<TransferStudentsFromOneClassToAnotherRequest> request, CancellationToken ct);
}
