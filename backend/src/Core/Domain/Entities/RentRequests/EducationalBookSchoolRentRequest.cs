using Domain.Entities.Books;
using Domain.Entities.SchoolStructure;
using Domain.Enums;

namespace Domain.Entities.RentRequests;

public class EducationalBookSchoolRentRequest
{
    public Guid Id { get; private set; }

    public SchoolGround DebtorSchoolGround { get; private set; }

    public SchoolGround OwnerSchoolGround { get; private set; }

    public EducationalBookInBalance Book { get; private set; }

    public int RequestingBookCount { get; private set; }

    public int? OwnerReadyGiveBookCount { get; private set; }

    public RentRequestStatus RequestStatus { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public SchoolGround CreatedBy { get; private set; }

    public bool ViewedUpdatesByRequestedSide { get; private set; }

    public bool ViewedUpdatesByRequestingSide { get; private set; }

    public bool ResolvedByRequestingSide { get; private set; }

    public bool ResolvedByRequestedSide { get; private set; }

    public bool SendByOwner { get; private set; }

    public bool ReceivedByDebtor { get; private set; }

    public IReadOnlyCollection<EducationalBookSchoolRentRequestConversationMessage> Messages { get; private set; } = new List<EducationalBookSchoolRentRequestConversationMessage>();

    private EducationalBookSchoolRentRequest() { }

    public EducationalBookSchoolRentRequest(Guid id, 
        SchoolGround debtorSchoolGround, 
        SchoolGround ownerSchool, 
        EducationalBookInBalance book, 
        int requestingBookCount, 
        int? ownerReadyGiveBookCount,
        RentRequestStatus requestStatus,
        DateTime createdAt,
        SchoolGround createdBy, 
        bool viewedUpdatesByRequestedSide, 
        bool viewedUpdatesByRequestingSide, 
        bool resolvedByRequestingSide, 
        bool resolvedByRequestedSide, 
        bool sendByOwner, 
        bool receivedByDebtor)
    {
        Id = id;
        DebtorSchoolGround = debtorSchoolGround;
        OwnerSchoolGround = ownerSchool;
        Book = book;
        RequestingBookCount = requestingBookCount;
        OwnerReadyGiveBookCount = ownerReadyGiveBookCount;
        RequestStatus = requestStatus;
        CreatedAt = createdAt;
        CreatedBy = createdBy;
        ViewedUpdatesByRequestedSide = viewedUpdatesByRequestedSide;
        ViewedUpdatesByRequestingSide = viewedUpdatesByRequestingSide;
        ResolvedByRequestingSide = resolvedByRequestingSide;
        ResolvedByRequestedSide = resolvedByRequestedSide;
        SendByOwner = sendByOwner;
        ReceivedByDebtor = receivedByDebtor;
    }
}
