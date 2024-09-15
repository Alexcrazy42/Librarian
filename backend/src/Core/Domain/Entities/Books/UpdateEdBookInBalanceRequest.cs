using Domain.Enums;

namespace Domain.Entities.Books;

public record UpdateEdBookInBalanceRequest(Guid Id, Guid BaseEdBookId, decimal Price, BookCondition Condition, int Year, string Note)
{
    public Guid Id { get; private set; } = Id;

    public Guid BaseEdBookId { get; private set; } = BaseEdBookId;

    public decimal Price { get; private set; } = Price;

    public BookCondition Condition { get; private set; } = Condition;

    public int Year { get; private set; } = Year;

    public string Note { get; private set; } = Note;
}
