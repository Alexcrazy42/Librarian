using Domain.Contracts.Requests.SchoolRentsRequests;
using Domain.Entities.Books;
using Domain.Entities.RentRequests;
using Domain.Entities.Rents.School;
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

        var request = await schoolBookRentRepository.GetAsync(requestId, ct);

        book.InPlaceCount -= request.RequestingBookCount;

        var newEdBookInBalance = new EducationalBookInBalance(
            Guid.NewGuid(),
            book.BaseEducationalBook,
            book.Price,
            book.Condition,
            book.Year,
            book.Note,
            request.RequestingBookCount,
            request.RequestingBookCount,
            true,
            request.DebtorSchoolGround,
            request.OwnerSchoolGround
        );

        var newEdBookRent = new EducationalBookSchoolRent(
            Guid.NewGuid(),
            book,
            newEdBookInBalance,
            request.OwnerSchoolGround,
            request.DebtorSchoolGround,
            false,
            false,
            false,
            request.RequestingBookCount,
            request.EndRentAt);

        request.ReceivedByDebtor = true;
        request.IsArchived = true;

        await schoolBookRentRepository.ReceiveBooksByDebtorAsync(request, newEdBookInBalance, newEdBookRent, ct);
    }

    public async Task<EducationalBookSchoolRentRequest> CreateSchoolRentAsync(CreateEdBookSchoolRentRequest request, CancellationToken ct)
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
            isArchived: false,
            endRentAt: request.EndRentAt
        );

        return await schoolBookRentRepository.CreateAsync(edBookSchoolRentRequest, ct);
    }

    public async Task<EducationalBookSchoolRentRequestConversationMessage> SendMessageToDebtorRequestAsync(SendMessageToRentRequestRequest request, CancellationToken ct)
    {
        var rentRequest = new EducationalBookSchoolRentRequest(request.RentRequestId);

        if (request.Status == SchoolRentConversationMessageStatus.Accept)
        {
            rentRequest.ResolvedByRequestedSide = true;
            rentRequest.ResolvedByRequestingSide = true;
        }

        rentRequest.ViewedUpdatesByRequestingSide = false;

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

        if (request.ReadyGiveBookCount != null)
        {
            rentRequest.OwnerReadyGiveBookCount = request.ReadyGiveBookCount;
            message.OwnerReadyGiveBook = request.ReadyGiveBookCount;
        }

        if (request.ReadyEndRentAt != null)
        {
            rentRequest.OwnerReadyToEndRentAt = request.ReadyEndRentAt;
            message.OwnerReadyToEndRentAt = request.ReadyEndRentAt;
        }
        
        return await schoolBookRentRepository.SendMessageToDebtorRequestAsync(message, ct);
    }

    public async Task<EducationalBookSchoolRentRequestConversationMessage> SendMessageToOwnerResponseAsync(SendMessageToRentRequestResponseRequest request, CancellationToken ct)
    {
        var rentRequest = new EducationalBookSchoolRentRequest(request.RentRequestId);

        rentRequest.ViewedUpdatesByRequestedSide = false;

        var message = new EducationalBookSchoolRentRequestConversationMessage(
            Guid.NewGuid(),
            rentRequest: rentRequest,
            messageSender: new SchoolGround(request.GroundSenderId),
            message: request.Message,
            status: SchoolRentConversationMessageStatus.Message,
            createdAt: DateTime.UtcNow,
            viewedByReveiver: false
        );

        if (request.ChangeRequestedBookCount != null)
        {
            rentRequest.RequestingBookCount = (int)request.ChangeRequestedBookCount;
            message.ChangeRequestedBookCount = request.ChangeRequestedBookCount;
        }

        if (request.ChangeEndRentAt != null)
        {
            rentRequest.EndRentAt = (DateOnly)request.ChangeEndRentAt;
            message.ChangeDebtorEndRentAt = request.ChangeEndRentAt;
        }

        return await schoolBookRentRepository.SendMessageToOwnerResponseAsync(message, ct);
    }

    public async Task SetVisibleOfRequestAsync(Guid requestId, CancellationToken ct)
    {
        await schoolBookRentRepository.SetVisibleOfRequestAsync(requestId, ct);
    }

    public async Task SetVisibleOfResponseAsync(Guid requestId, CancellationToken ct)
    {
        await schoolBookRentRepository.SetVisibleOfResponseAsync(requestId, ct);
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
