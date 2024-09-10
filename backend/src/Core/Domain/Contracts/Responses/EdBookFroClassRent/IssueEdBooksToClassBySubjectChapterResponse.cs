namespace Domain.Contracts.Responses.EdBookFroClassRent;

public class StudentEdBookInBalanceRentResponse
{
    public Guid Id { get; set; }

    public Guid StudentId { get; set; }

    public Guid EdBookInBalanceId { get; set; }
}