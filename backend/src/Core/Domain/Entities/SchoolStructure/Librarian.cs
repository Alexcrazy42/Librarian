using Domain.Common;

namespace Domain.Entities.SchoolStructure;

public class Librarian : Person
{
    public Guid Id { get; private set; }

    public School School { get; private set; }

    public SchoolGround? Ground { get; private set; }

    public bool IsGeneral { get; private set; }

    private Librarian() : base() { }

    public Librarian(Guid id,
        string surname,
        string name,
        string patronymic,
        School school,
        bool isGeneral)
        : base(surname, name, patronymic)
    {
        Id = id;
        School = school;
        IsGeneral = isGeneral;
    }
}
