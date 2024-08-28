using Domain.Entities.Books;
using Domain.Entities.SchoolStructure;

namespace Domain.Entities.Rents;

internal class ImaginativeBookStudentRent
{
    public Guid Id { get; private set; }

    public Student Student { get; private set; }


    public bool IsArchived { get; private set; }

    public DateOnly StartDate { get; private set; }

    public DateOnly EndDate { get; private set; }
}
