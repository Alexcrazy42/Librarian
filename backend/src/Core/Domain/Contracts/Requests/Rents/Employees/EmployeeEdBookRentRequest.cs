namespace Domain.Contracts.Requests.Rents.Employees;

public record EmployeeEdBookRentRequest(Guid EmployeeId, Guid EdBookInBalanceId, int Count, DateOnly StartDate, DateOnly EndDate);