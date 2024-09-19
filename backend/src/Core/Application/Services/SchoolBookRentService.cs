using Domain.Contracts.Requests.SchoolRentsRequests;
using Domain.Entities.Books;
using Domain.Entities.RentRequests;
using Domain.Entities.SchoolStructure;
using Domain.Enums;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Application.Services;

internal class SchoolBookRentService : ISchoolBookRentService
{
    private readonly ISchoolBookRentRepository schoolBookRentRepository;

    public SchoolBookRentService(ISchoolBookRentRepository schoolBookRentRepository)
    {
        this.schoolBookRentRepository = schoolBookRentRepository;
    }

    public async Task CloseRequestByDebtorAsync(Guid requestId, CancellationToken ct)
    {
        await schoolBookRentRepository.CloseRequestByDebtorAsync(requestId, ct);
    }

    public async Task CloseRequestByOwnerAsync(Guid requestId, CancellationToken ct)
    {
        await schoolBookRentRepository.CloseRequestByOwnerAsync(requestId, ct);
    }

    public async Task SendBooksByOwnerAsync(Guid requestId, CancellationToken ct)
    {
        await schoolBookRentRepository.SendBooksByOwnerAsync(requestId, ct);
    }

    public async Task ReceiveBooksByDebtorAsync(Guid requestId, CancellationToken ct)
    {
        var book = await schoolBookRentRepository.GetEdBookInBalanceAsync(requestId, ct);
        var debtorGround = await schoolBookRentRepository.GetDebtorGroundAsync(requestId, ct);

        book.DebtorSchoolGround = debtorGround;

        var request = new EducationalBookSchoolRentRequest(requestId);

        request.ReceivedByDebtor = true;
        request.IsArchived = true;

        await schoolBookRentRepository.ReceiveBooksByDebtorAsync(request, ct);
    }

    public async Task SetVisibleOfRequestAsync(Guid requestId, CancellationToken ct)
    {
        await schoolBookRentRepository.SetVisibleOfRequestAsync(requestId, ct);
    }

    public async Task SetVisibleOfResponseAsync(Guid requestId, CancellationToken ct)
    {
        await schoolBookRentRepository.SetVisibleOfResponseAsync(requestId, ct);
    }

    public async Task<EducationalBookSchoolRentRequest> CreateSchoolRentAsync(CreateSchoolRentRequest request, CancellationToken ct)
    {
        var debtor = new SchoolGround(request.DebtorSchoolGroundId);

        var edBookSchoolRentRequest = new EducationalBookSchoolRentRequest(
            id: Guid.NewGuid(),
            debtorSchoolGround: debtor,
            ownerSchool: new SchoolGround(request.OwnerSchoolGroundId),
            book: new EducationalBookInBalance(request.EdBookInBalanceId),
            requestingBookCount: request.RequestingBookCount,
            ownerReadyGiveBookCount: null,
            requestStatus: RentRequestStatus.None,
            createdAt: DateTime.UtcNow,
            createdBy: debtor,
            viewedUpdatesByRequestedSide: false,
            viewedUpdatesByRequestingSide: false,
            resolvedByRequestingSide: false,
            resolvedByRequestedSide: false,
            sendByOwner: false,
            receivedByDebtor: false,
            isArchived: false
        );

        return await schoolBookRentRepository.CreateAsync(edBookSchoolRentRequest, ct);
    }

    public async Task<EducationalBookSchoolRentRequestConversationMessage> SendMessageToDebtorRequestAsync(SendMessageToRentRequestRequest request, CancellationToken ct)
    {
        var rentRequest = new EducationalBookSchoolRentRequest(request.RentRequestId);

        if (request.ReadyGiveBookCount != 0)
        {
            rentRequest.OwnerReadyGiveBookCount = request.ReadyGiveBookCount;
        }

        if (rentRequest.RequestStatus == RentRequestStatus.Accept)
        {
            rentRequest.ResolvedByRequestedSide = true;
            rentRequest.ResolvedByRequestingSide = true;
        }

        rentRequest.RequestStatus = GetRequestStatusBySendedMessage(request.Status);

        var message = new EducationalBookSchoolRentRequestConversationMessage(
            Guid.NewGuid(),
            rentRequest: rentRequest,
            messageSender: new SchoolGround(request.GroundSenderId),
            message: request.Message,
            status: request.Status,
            createdAt: DateTime.UtcNow,
            viewedByReveiver: false
        );

        return await schoolBookRentRepository.SendMessageToDebtorRequestAsync(message, ct);
    }

    public async Task<EducationalBookSchoolRentRequestConversationMessage> SendMessageToOwnerResponseAsync(SendMessageToRentRequestResponseRequest request, CancellationToken ct)
    {
        var rentRequest = new EducationalBookSchoolRentRequest(request.RentRequestId);

        if (request.ChangeRequestedBookCount != 0)
        {
            rentRequest.RequestingBookCount = (int)request.ChangeRequestedBookCount;
        }

        var message = new EducationalBookSchoolRentRequestConversationMessage(
            Guid.NewGuid(),
            rentRequest: rentRequest,
            messageSender: new SchoolGround(request.GroundSenderId),
            message: request.Message,
            status: SchoolRentConversationMessageStatus.Message,
            createdAt: DateTime.UtcNow,
            viewedByReveiver: false
        );

        return await schoolBookRentRepository.SendMessageToOwnerResponseAsync(message, ct);
    }

    private RentRequestStatus GetRequestStatusBySendedMessage(SchoolRentConversationMessageStatus messageStatus)
    {
        return messageStatus switch
        {
            SchoolRentConversationMessageStatus.Accept => RentRequestStatus.Accept,
            SchoolRentConversationMessageStatus.ReadyGivePartOfBook => RentRequestStatus.ReadyGivePartOfBooks,
            SchoolRentConversationMessageStatus.Reject => RentRequestStatus.Reject,
            _ => RentRequestStatus.None
        };
    }
}
