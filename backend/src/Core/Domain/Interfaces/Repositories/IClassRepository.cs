using Domain.Entities.SchoolStructure;

namespace Domain.Interfaces.Repositories;

public interface IClassRepository
{
    public Task<(School School, SchoolGround SchoolGround, SchoolClass Class)> GetSchoolDetailsAsyncByClassIdAsync(Guid classId, CancellationToken ct);
}
