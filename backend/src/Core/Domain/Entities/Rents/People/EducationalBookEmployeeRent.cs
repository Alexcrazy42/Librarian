using Domain.Entities.Books;
using Domain.Entities.SchoolStructure;

namespace Domain.Entities.Rents.People;

public class EducationalBookEmployeeRent
{
    public Guid Id { get; private set; }

    public Employee Employee { get; private set; }

    public EducationalBookInBalance Book { get; private set; }

    public int Count { get; private set; }

    public bool IsArchived { get; private set; }

    public DateOnly StartDate { get; private set; }

    public DateOnly EndDate { get; private set; }
}
