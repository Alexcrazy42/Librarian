using Domain.Contracts.Requests.School;
using Domain.Entities.SchoolStructure;

namespace Domain.Interfaces.Services;

public interface ISchoolService
{
    public Task<School> CreateSchoolStructureAsync(CreateSchoolStructureRequest request, CancellationToken cancellationToken);
}
