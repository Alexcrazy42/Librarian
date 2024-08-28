using Domain.Common;
using Domain.Enums;

namespace Domain.Entities.SchoolStructure;

public sealed class Employee : Person
{
    public Guid Id { get; private set; }

    public EmployeeStatusEnum EmployeeStatus { get; private set; }

    public School School { get; private set; }

    public SchoolPlayground Playground { get; private set; }

    public SchoolClass? ManagementClass { get; private set; }

    private Employee()
    { }

    public Employee(Guid id,
        string surname,
        string name,
        string patronymic,
        EmployeeStatusEnum employeeStatus,
        School school,
        SchoolPlayground  playground,
        SchoolClass? managementClass)
        : base(surname, name, patronymic)
    {
        Id = id;
        EmployeeStatus = employeeStatus;
        School = school;
        Playground = playground;
        ManagementClass = managementClass;
    }
}
