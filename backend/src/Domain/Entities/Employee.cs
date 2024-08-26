using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public sealed class Employee : Person
{
    public Guid Id { get; set; }

    public EmployeeStatusEnum EmployeeStatus { get; set; }

    public School School { get; set; }

    public SchoolClass? ManagementClass { get; set; }

    private Employee()
    { }

    public Employee(Guid id,
        string surname,
        string name,
        string patronymic,
        EmployeeStatusEnum employeeStatus,
        School school,
        SchoolClass? managementClass)
        : base(surname, name, patronymic)
    {
        Id = id;
        EmployeeStatus = employeeStatus;
        School = school;
        ManagementClass = managementClass;
    }
}
