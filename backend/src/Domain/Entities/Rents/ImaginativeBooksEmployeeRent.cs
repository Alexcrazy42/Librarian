namespace Domain.Entities.Rents;

internal class ImaginativeBooksEmployeeRent
{
    public Guid Id { get; }

    public Employee Employee { get; }

    public ImaginativeBook Book { get; }

    public int Count { get; }

    public bool IsArchived { get; }

    public DateOnly StartDate { get; }

    public DateOnly EndDate { get; }
}
