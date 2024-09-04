using Domain.Common;

namespace Domain.Entities.SchoolStructure;

public class Student : Person
{
    public Guid Id { get; private set; }

    public bool IsArchived { get; private set; }

    public SchoolClass? SchoolClass { get; private set; }

    public School School { get; private set; }

    public SchoolGround Ground { get; private set; }

    private Student()
    { }

    public Student(Guid id,
        bool isArchived,
        string surname,
        string name,
        string patronymic,
        SchoolClass schoolClass,
        School school,
        SchoolGround ground)
        : base(surname, name, patronymic)
    {
        Id = id;
        SchoolClass = schoolClass;
        School = school;
        IsArchived = isArchived;
        Ground = ground;
    }
}
