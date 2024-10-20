using Domain.Common;

namespace Domain.Entities.SchoolStructure;

public class Librarian : Person
{
    private bool _isGeneral;

    public Guid Id { get; private set; }

    public SchoolGround Ground { get; private set; }

    public School School { get; private set; }

    public bool IsGeneral
    {
        get
        {
            return _isGeneral;
        }
        set
        {
            _isGeneral = value;
        }
    }

    private Librarian() : base() { }

    public Librarian(Guid id,
        string surname,
        string name,
        DateOnly birthDate,
        string? patronymic,
        bool isGeneral,
        SchoolGround ground,
        School school)
        : base(surname, name, birthDate, patronymic)
    {
        Id = id;
        IsGeneral = isGeneral;
        Ground = ground;
        School = school;
    }
}
