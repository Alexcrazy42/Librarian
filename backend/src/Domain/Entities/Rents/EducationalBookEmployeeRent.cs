namespace Domain.Entities.Rents;

public class EducationalBookEmployeeRent
{
    public Guid Id { get; }

    public Employee Employee { get; }

    public EducationalBook Book { get; }

    public int Count { get; }

    public bool IsArchived { get; }

    public DateOnly StartDate { get; }

    public DateOnly EndDate { get; }
}
