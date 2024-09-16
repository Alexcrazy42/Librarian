using Domain.Entities.RentRequests;

namespace Domain.Interfaces.Repositories;

public interface ISchoolBookRentRepository
{
    public Task<EducationalBookSchoolRentRequest> GetAsync(Guid id, CancellationToken ct);

    public Task<EducationalBookSchoolRentRequest> CreateAsync(EducationalBookSchoolRentRequest entity, CancellationToken ct);

    public Task<IReadOnlyCollection<EducationalBookSchoolRentRequest>> GetAllSendedRequests(Guid groundId, CancellationToken ct);

    public Task<IReadOnlyCollection<EducationalBookSchoolRentRequest>> GetAllReceivedRequestsAsync(Guid groundId, CancellationToken ct);
}