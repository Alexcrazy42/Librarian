using Domain.Enums;

namespace Domain.Contracts.Requests.EdBooks;

public class CreateEdBookRequest
{
    public Guid BaseEdBookId { get; set; }

    public decimal Price { get; private set; }

    public BookCondition Condition { get; private set; }

    public int Year { get; private set; }

    public string Note { get; private set; }

    public int InPlaceCount { get; private set; }

    public int TotalCount { get; private set; }

    public Guid GroundId { get; private set; }

    public Guid SupplyId { get; private set; }
}
