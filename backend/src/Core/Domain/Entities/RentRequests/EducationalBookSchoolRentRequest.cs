using Domain.Entities.Books;
using Domain.Entities.SchoolStructure;
using Domain.Enums;
using Microsoft.VisualBasic;

namespace Domain.Entities.RentRequests;

public class EducationalBookSchoolRentRequest
{
    public Guid Id { get; private set; }

    public SchoolGround DebtorSchoolGround { get; private set; }

    public SchoolGround OwnerSchoolGround { get; private set; }

    public EducationalBookInBalance Book { get; private set; }

    public int RequestingBookCount { get; set; }

    public DateOnly EndRentAt { get; set; }

    public int? OwnerReadyGiveBookCount { get; set; }

    public DateOnly? OwnerReadyToEndRentAt { get; set; }

    public RentRequestStatus RequestStatus { get; set; }

    public DateTime CreatedAt { get; private set; }

    public SchoolGround CreatedBy { get; private set; }

    public bool ViewedUpdatesByRequestedSide { get; set; }

    public bool ViewedUpdatesByRequestingSide { get; set; }

    public bool ResolvedByRequestingSide { get; set; }

    public bool ResolvedByRequestedSide { get; set; }

    public bool SendByOwner { get; set; }

    public bool ReceivedByDebtor { get; set; }

    public bool IsArchived { get; set; }

    public IReadOnlyCollection<EducationalBookSchoolRentRequestConversationMessage> Messages { get; private set; } = new List<EducationalBookSchoolRentRequestConversationMessage>();

    private EducationalBookSchoolRentRequest() { }

    public EducationalBookSchoolRentRequest(Guid id)
    {
        Id = id;
    }

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
        bool receivedByDebtor,
        bool isArchived,
        DateOnly endRentAt)
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
        IsArchived = isArchived;
        EndRentAt = endRentAt;
    }
}