using Domain.Entities.SchoolStructure;

namespace Domain.Interfaces.Repositories;

public interface IStudentRepository
{
    public Task<IReadOnlyCollection<Student>> AddStudentsToClassAsync(IReadOnlyCollection<Student> students, CancellationToken ct);

    public Task<IReadOnlyCollection<Student>> GetStudentsFromClassAsync(Guid classId, CancellationToken ct);
}
