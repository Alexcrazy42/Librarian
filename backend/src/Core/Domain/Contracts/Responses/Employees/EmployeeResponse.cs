using Domain.Common;
using Domain.Enums;

namespace Domain.Contracts.Responses.Employees;

public class EmployeeResponse : Person
{
    public Guid Id { get; set; }

    public EmployeeStatusEnum EmployeeStatus { get; set; }

    public Guid? SchoolId { get; set; }

    public Guid? SchoolGroundId { get; set; }

    public SchoolClassResponse? ManagementClass { get; set; }
}

public class SchoolClassResponse
{
    public Guid Id { get; set; }

    public int Number { get; set; }

    public string Name { get; set; }
}