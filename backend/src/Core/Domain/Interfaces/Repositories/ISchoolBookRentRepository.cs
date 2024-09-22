using Domain.Entities.Books;
using Domain.Entities.RentRequests;
using Domain.Entities.Rents.School;
using Domain.Entities.SchoolStructure;

namespace Domain.Interfaces.Repositories;

public interface ISchoolBookRentRepository
{
    public Task<EducationalBookSchoolRentRequest> GetAsync(Guid id, CancellationToken ct);

    public Task<EducationalBookSchoolRentRequest> CreateAsync(EducationalBookSchoolRentRequest entity, CancellationToken ct);

    public Task<IReadOnlyCollection<EducationalBookSchoolRentRequest>> GetAllSendedRequests(Guid groundId, CancellationToken ct);

    public Task<IReadOnlyCollection<EducationalBookSchoolRentRequest>> GetAllReceivedRequestsAsync(Guid groundId, CancellationToken ct);

    public Task<EducationalBookSchoolRentRequestConversationMessage> SendMessageToDebtorRequestAsync(EducationalBookSchoolRentRequestConversationMessage message, CancellationToken ct);

    public Task<EducationalBookSchoolRentRequestConversationMessage> SendMessageToOwnerResponseAsync(EducationalBookSchoolRentRequestConversationMessage message, CancellationToken ct);

    public Task CloseRequestByDebtorAsync(Guid requestId, CancellationToken ct);

    public Task CloseRequestByOwnerAsync(Guid requestId, CancellationToken ct);

    public Task SendBooksByOwnerAsync(Guid requestId, CancellationToken ct);

    public Task ReceiveBooksByDebtorAsync(EducationalBookSchoolRentRequest request, EducationalBookInBalance newEdBook, EducationalBookSchoolRent newEdBookRent, CancellationToken ct);

    public Task<EducationalBookInBalance> GetEdBookInBalanceAsync(Guid requestId, CancellationToken ct);
    
    public Task<SchoolGround> GetDebtorGroundAsync(Guid requestId, CancellationToken ct);
    public Task ChangeBookCountAsync(EducationalBookSchoolRentRequest request, CancellationToken ct);
    
    public Task SetVisibleOfRequestAsync(Guid requestId, CancellationToken ct);

    public Task SetVisibleOfResponseAsync(Guid requestId, CancellationToken ct);
}