using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public sealed class SchoolEmployee : Person
{
    public EmployeeStatusEnum EmployeeStatus { get; set; }

    public SchoolClass? ManagementClass { get; set; }

    public SchoolEmployee(string surname,
        string name,
        string patronymic,
        EmployeeStatusEnum employeeStatus,
        SchoolClass? managementClass)
        : base(surname, name, patronymic)
    {
        EmployeeStatus = employeeStatus;
        ManagementClass = managementClass;
    }
}
