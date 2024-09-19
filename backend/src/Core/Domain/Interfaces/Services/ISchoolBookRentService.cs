using Domain.Contracts.Requests.SchoolRentsRequests;
using Domain.Entities.RentRequests;

namespace Domain.Interfaces.Services;

public interface ISchoolBookRentService
{
    public Task<EducationalBookSchoolRentRequest> CreateSchoolRentAsync(CreateSchoolRentRequest request, CancellationToken ct);

    public Task SetVisibleOfRequestAsync(Guid requestId, CancellationToken ct);

    public Task SetVisibleOfResponseAsync(Guid requestId, CancellationToken ct);

    public Task<EducationalBookSchoolRentRequestConversationMessage> SendMessageToDebtorRequestAsync(SendMessageToRentRequestRequest request, CancellationToken ct);

    public Task<EducationalBookSchoolRentRequestConversationMessage> SendMessageToOwnerResponseAsync(SendMessageToRentRequestResponseRequest request, CancellationToken ct);
    
    public Task ReceiveBooksByDebtorAsync(Guid requestId, CancellationToken ct);

    public Task CloseRequestByOwnerAsync(Guid requestId, CancellationToken ct);

    public Task SendBooksByOwnerAsync(Guid requestId, CancellationToken ct);

    public Task CloseRequestByDebtorAsync(Guid requestId, CancellationToken ct);
}