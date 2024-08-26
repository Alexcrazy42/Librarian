namespace Domain.Entities.Rents;

internal class ImaginativeBookStudentRent
{
    public Guid Id { get; }

    public Student Student { get; }

    public ImaginativeBook Book { get; }

    public bool IsArchived { get; }

    public DateOnly StartDate { get; }

    public DateOnly EndDate { get; }
}
