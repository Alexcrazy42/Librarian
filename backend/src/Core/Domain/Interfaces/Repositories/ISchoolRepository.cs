using Domain.Entities.SchoolStructure;

namespace Domain.Interfaces.Repositories;

public interface ISchoolRepository
{
    public Task<School> GetById(Guid schoolId, CancellationToken cancellationToken);

    public Task<School> CreateSchoolStructureAsync(School school, CancellationToken cancellationToken);
}
