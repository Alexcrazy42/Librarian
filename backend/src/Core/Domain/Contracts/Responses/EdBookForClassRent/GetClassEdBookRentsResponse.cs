using Domain.Contracts.Responses.EdBooks;

namespace Domain.Contracts.Responses.EdBookForClassRent;

public class GetClassEdBookRentsResponse
{
    public Guid Id { get; set; }

    public Guid StudentId { get; set; }

    public EdBookInBalanceResponse EdBook { get; set; }

    public int Count { get; set; }

    public bool IsOverdue { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }
}
