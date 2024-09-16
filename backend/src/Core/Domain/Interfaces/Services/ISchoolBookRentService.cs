using Domain.Contracts.Requests.SchoolRentsRequests;
using Domain.Entities.RentRequests;

namespace Domain.Interfaces.Services;

public interface ISchoolBookRentService
{
    public Task<EducationalBookSchoolRentRequest> CreateSchoolRentAsync(CreateSchoolRentRequest request, CancellationToken ct);
}