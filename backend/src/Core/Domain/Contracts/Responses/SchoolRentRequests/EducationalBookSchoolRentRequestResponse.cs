using Domain.Enums;

namespace Domain.Contracts.Responses.SchoolRentRequests;

public class EducationalBookSchoolRentRequestResponse
{
    public Guid Id { get; set; }

    public Guid DebtorGroundId { get; set; }

    public Guid OwnerGroundId { get; set; }

    public Guid BookId { get; set; }

    public int RequestingBookCount { get; set; }

    public int? OwnerReadyGiveBookCount { get;  set; }

    public RentRequestStatus RequestStatus { get; set; }

    public DateTime CreatedAt { get; set; }

    public Guid CreatedBy { get; set; }

    public bool ViewedUpdatesByRequestedSide { get; set; }

    public bool ViewedUpdatesByRequestingSide { get; set; }

    public bool ResolvedByRequestingSide { get; set; }

    public bool ResolvedByRequestedSide { get; set; }

    public bool SendByOwner { get; set; }

    public bool ReceivedByDebtor { get; set; }
}