using Domain.Contracts.Requests.Employees;
using Domain.Entities.SchoolStructure;

namespace Domain.Interfaces.Repositories;

public interface IEmployeeRepository
{
    public Task<Employee> GetEmployeeAsync(Guid id, CancellationToken ct);

    public Task<Employee> CreateEmployeeAsync(CreateEmployeeRequest request, CancellationToken ct);

    public Task<Employee> UpdateEmployeeAsync(UpdateEmployeeRequest request, CancellationToken ct);

    public Task SetManagementClass(Employee employee, SchoolClass @class, CancellationToken ct);

    public Task DeleteEmployeeAsync(Guid id, CancellationToken ct);
}
