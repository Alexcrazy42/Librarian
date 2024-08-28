using Domain.Entities.Books;
using Domain.Entities.SchoolStructure;

namespace Domain.Entities.Rents;

public class EducationalBookStudentRent
{
    public Guid Id { get; private set; }

    public Student Student { get; private set; }

    public EducationalBookInBalance Book { get; private set; }

    public int Count { get; private set; }

    public bool IsArchived { get; private set; }

    public DateOnly StartDate { get; private set; }

    public DateOnly EndDate { get; private set; }
}
