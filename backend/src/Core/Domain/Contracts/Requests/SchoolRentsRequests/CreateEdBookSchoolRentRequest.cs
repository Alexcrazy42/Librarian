namespace Domain.Contracts.Requests.SchoolRentsRequests;

public record CreateEdBookSchoolRentRequest(Guid DebtorSchoolGroundId, Guid OwnerSchoolGroundId, Guid EdBookInBalanceId, int RequestingBookCount, DateOnly EndRentAt);
