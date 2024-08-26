namespace Domain.Entities.Rents;

public class EducationalBookStudentRent
{
    public Guid Id { get; }

    public Student Student { get; }

    public EducationalBook Book { get; }

    public int Count { get; }

    public bool IsArchived { get; }

    public DateOnly StartDate { get; }

    public DateOnly EndDate { get; }
}
