using Domain.Common;

namespace Domain.Entities.SchoolStructure;

public class Librarian : Person
{
    public Guid Id { get; private set; }

    public SchoolGround Ground { get; private set; }

    public School School { get; private set; }

    public bool IsGeneral { get; private set; }

    private Librarian() : base() { }

    public Librarian(Guid id,
        string surname,
        string name,
        string patronymic,
        bool isGeneral,
        SchoolGround ground,
        School school)
        : base(surname, name, patronymic)
    {
        Id = id;
        IsGeneral = isGeneral;
        Ground = ground;
        School = school;
    }
}
