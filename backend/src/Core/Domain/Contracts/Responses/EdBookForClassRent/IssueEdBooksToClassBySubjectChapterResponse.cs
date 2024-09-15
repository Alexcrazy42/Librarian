namespace Domain.Contracts.Responses.EdBookForClassRent;

public class StudentEdBookInBalanceRentResponse
{
    public Guid Id { get; set; }

    public Guid StudentId { get; set; }

    public Guid EdBookInBalanceId { get; set; }

    public int Count { get; set; }

    public bool IsOverdue { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }
}