using Domain.Common;
using Domain.Enums;

namespace Domain.Entities.SchoolStructure;

public sealed class Employee : Person
{
    public Guid Id { get; private set; }

    public EmployeeStatusEnum EmployeeStatus { get; private set; }

    public School School { get; private set; }

    public SchoolGround Ground { get; private set; }

    public SchoolClass? ManagementClass { get; private set; }

    public void SetManagementClass(SchoolClass mClass)
    {
        ManagementClass = mClass;
    }

    public void RemoveFromClassManager()
    {
        ManagementClass = null;
    }

    private Employee()
    { }

    public Employee(Guid id)
    {
        Id = id;
    }
    public Employee(Guid id,
        string surname,
        string name,
        DateOnly birthDate,
        string? patronymic,
        EmployeeStatusEnum employeeStatus,
        School school,
        SchoolGround  ground)
        : base(surname, name, birthDate, patronymic)
    {
        Id = id;
        EmployeeStatus = employeeStatus;
        School = school;
        Ground = ground;
    }
}
