using Domain.Contracts.Requests.Employees;
using Domain.Contracts.Responses.Employees;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("api/employees")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepository employeeRepository;
    private readonly IEmployeeService employeeService;

    public EmployeeController(IEmployeeRepository employeeRepository, IEmployeeService employeeService)
    {
        this.employeeRepository = employeeRepository;
        this.employeeService = employeeService;
    }

    [HttpGet("{id}")]
    public async Task<EmployeeResponse> GetEmployeeAsync([FromRoute] Guid id, CancellationToken ct)
    {
        var employee = await employeeRepository.GetEmployeeAsync(id, ct);

        return new EmployeeResponse()
        {
            Id = employee.Id,
            Surname = employee.Surname,
            Name = employee.Name,
            Patronymic = employee.Patronymic,
            EmployeeStatus = employee.EmployeeStatus,
            SchoolId = employee.School?.Id,
            SchoolGroundId = employee.Ground?.Id,
            ManagementClass = employee.ManagementClass != null 
                ?  new SchoolClassResponse()
                {
                    Id = employee.ManagementClass.Id,
                    Number = employee.ManagementClass.Number,
                    Name = employee.ManagementClass.Name
                } 
                : null
        };
    }

    [HttpPost]
    public async Task<EmployeeResponse> CreateEmployeeAsync([FromBody] CreateEmployeeRequest request, CancellationToken ct)
    {
        var employee = await employeeRepository.CreateEmployeeAsync(request, ct);

        return new EmployeeResponse()
        {
            Id = employee.Id,
            Surname = employee.Surname,
            Name = employee.Name,
            Patronymic = employee.Patronymic,
            EmployeeStatus = employee.EmployeeStatus,
            SchoolId = employee.School?.Id,
            SchoolGroundId = employee.Ground?.Id,
            ManagementClass = employee.ManagementClass != null
                ? new SchoolClassResponse()
                {
                    Id = employee.ManagementClass.Id,
                    Number = employee.ManagementClass.Number,
                    Name = employee.ManagementClass.Name
                }
                : null
        };
    }

    [HttpPut]
    public async Task<EmployeeResponse> UpdateEmployeeAsync([FromBody] UpdateEmployeeRequest request, CancellationToken ct)
    {
        var employee = await employeeRepository.UpdateEmployeeAsync(request, ct);

        return new EmployeeResponse()
        {
            Id = employee.Id,
            Surname = employee.Surname,
            Name = employee.Name,
            Patronymic = employee.Patronymic,
            EmployeeStatus = employee.EmployeeStatus,
            SchoolId = employee.School?.Id,
            SchoolGroundId = employee.Ground?.Id,
            ManagementClass = employee.ManagementClass != null
                ? new SchoolClassResponse()
                {
                    Id = employee.ManagementClass.Id,
                    Number = employee.ManagementClass.Number,
                    Name = employee.ManagementClass.Name
                }
                : null
        };
    }

    [HttpPut("{id}/{classId}/make-class-manager")]
    public async Task MakeClassManagerAsync([FromRoute] Guid id, [FromRoute] Guid classId, CancellationToken ct)
    {
        await employeeService.MakeClassManagerAsync(id, classId, ct);
    }

    [HttpDelete("{id}")]
    public async Task DeleteEmployeeAsync([FromRoute] Guid id, CancellationToken ct)
    {
        await employeeService.DeleteEmployeeAsync(id, ct);
    }
}