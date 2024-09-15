using Domain.Contracts.Requests.School;
using Domain.Entities.SchoolStructure;

namespace Domain.Interfaces.Repositories;

public interface ISchoolRepository
{
    public Task<School> GetById(Guid schoolId, CancellationToken ct);

    public Task<SchoolGround> GetGroundWithClassesById(Guid groundId, CancellationToken ct);

    public Task<School> CreateSchoolStructureAsync(School school, CancellationToken ct);

    public Task<School> UpdateSchoolAsync(UpdateSchoolRequest request, CancellationToken ct);

    public Task<SchoolGround> UpdateGroundAsync(UpdateSchoolGroundRequest request, CancellationToken ct);

    public Task<(School School, SchoolGround SchoolGround)> GetSchoolAndGroundByGroundId(Guid groundId, CancellationToken ct);
    public Task<Librarian> UpdateLibrarianAsync(UpdateLibrarianRequest request, CancellationToken ct);
}
