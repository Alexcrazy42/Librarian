namespace Domain.Contracts.Requests.Rents.Students;

public record StudentEdBookRentRequest(Guid StudentId, Guid EdBookInBalanceId, int Count, DateOnly StartDate, DateOnly EndDate);
