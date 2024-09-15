using Domain.Enums;

namespace Domain.Contracts.Requests.EdBooks;

public class CreateEdBookInBalanceRequest
{
    public Guid BaseEdBookId { get; set; }

    public decimal Price { get; set; }

    public BookCondition Condition { get; set; }

    public int Year { get; set; }

    public string Note { get; set; }

    public int Count { get; set; }

    public Guid GroundId { get; set; }

    public Guid SupplyId { get; set; }
}
