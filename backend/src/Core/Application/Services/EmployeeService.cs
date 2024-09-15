using Domain.Common.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Application.Services;

internal class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository employeeRepository;
    private readonly IEdBookForEmployeeRentRepository edBookForEmployeeRentRepository;
    private readonly IClassRepository classRepository;

    public EmployeeService(IEmployeeRepository employeeRepository, 
        IClassRepository classRepository)
    {
        this.employeeRepository = employeeRepository;
        this.classRepository = classRepository;
    }

    public async Task MakeClassManagerAsync(Guid id, Guid classId, CancellationToken ct)
    {
        var employee = await employeeRepository.GetEmployeeAsync(id, ct);
        var @class = await classRepository.GetClassWithManagerAsync(classId, ct);

        @class.Manager?.RemoveFromClassManager();

        employee.SetManagementClass(@class);

        await employeeRepository.SetManagementClass(employee, @class, ct);
    }

    public async Task DeleteEmployeeAsync(Guid id, CancellationToken ct)
    {
        var rents = await edBookForEmployeeRentRepository.GetEmployeeEdBookRentsAsync(id, ct);

        if (rents.Count() > 0)
        {
            throw new CommonException("Невозможно удалить работника, пока у него есть непогашенные долги!");
        }

        await employeeRepository.DeleteEmployeeAsync(id, ct);
    }
}
