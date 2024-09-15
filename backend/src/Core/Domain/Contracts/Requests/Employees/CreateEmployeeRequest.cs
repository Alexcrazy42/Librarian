using Domain.Common;
using Domain.Enums;

namespace Domain.Contracts.Requests.Employees;

public class CreateEmployeeRequest : Person
{
    public EmployeeStatusEnum EmployeeStatus { get; set; }

    public Guid SchoolId { get; set; }

    public Guid SchoolGroundId { get; set; }

    public Guid? ManagementClassId { get; set; }
}