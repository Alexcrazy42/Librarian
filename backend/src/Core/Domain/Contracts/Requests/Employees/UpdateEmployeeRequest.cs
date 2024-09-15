using Domain.Common;
using Domain.Enums;

namespace Domain.Contracts.Requests.Employees;

public class UpdateEmployeeRequest : Person
{
    public Guid Id { get; set; }

    public EmployeeStatusEnum EmployeeStatus { get; set; }

    public Guid SchoolId { get; set; }

    public Guid SchoolGroundId { get; set; }

    public Guid? ManagementClassId { get; set; }
}
