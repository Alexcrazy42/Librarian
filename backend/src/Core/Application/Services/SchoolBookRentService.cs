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
            receivedByDebtor: false
        );

        return await schoolBookRentRepository.CreateAsync(edBookSchoolRentRequest, ct);
    }
}
