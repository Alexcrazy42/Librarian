using Domain.Entities.Books;
using Domain.Entities.SchoolStructure;

namespace Domain.Entities.Rents;

internal class ImaginativeBooksEmployeeRent
{
    public Guid Id { get; private set; }

    public Employee Employee { get; private set; }


    public int Count { get; private set; }

    public bool IsArchived { get; private set; }

    public DateOnly StartDate { get; private set; }

    public DateOnly EndDate { get; private set; }
}
