namespace Domain.Contracts.Requests.SchoolRentsRequests;

public record CreateSchoolRentRequest(Guid DebtorSchoolGroundId, Guid OwnerSchoolGroundId, Guid EdBookInBalanceId, int RequestingBookCount);
