using Domain.Contracts.Requests.Employees;
using Domain.Entities.SchoolStructure;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Store.Db;

namespace Repositories.Repositories;

internal class EmployeeRepository : IEmployeeRepository
{
    private readonly LibraryDbContext libraryDbContext;

    public EmployeeRepository(LibraryDbContext libraryDbContext)
    {
        this.libraryDbContext = libraryDbContext;
    }

    public async Task<Employee> GetEmployeeAsync(Guid id, CancellationToken ct)
    {
        return await libraryDbContext.Employees
            .Include(x => x.ManagementClass)
            .Include(x => x.School)
            .Include(x => x.Ground)
            .FirstOrDefaultAsync(x => x.Id == id, ct)
            ?? throw new NotImplementedException("Работник не найден!");
    }

    public async Task<Employee> CreateEmployeeAsync(CreateEmployeeRequest request, CancellationToken ct)
    {
        var employee = new Employee(
            Guid.NewGuid(),
            request.Surname,
            request.Name,
            request.Patronymic,
            request.EmployeeStatus,
            new School(request.SchoolId),
            new SchoolGround(request.SchoolGroundId)
        );

        libraryDbContext.Attach(employee.School);
        libraryDbContext.Attach(employee.Ground);

        if (request.ManagementClassId != Guid.Empty)
        {
            employee.SetManagementClass(new SchoolClass((Guid)request.ManagementClassId));
            libraryDbContext.Attach(employee.ManagementClass);
        }
        
        libraryDbContext.Employees.Add(employee);

        await libraryDbContext.SaveChangesAsync(ct);

        return employee;
    }

    public Task<Employee> UpdateEmployeeAsync(UpdateEmployeeRequest request, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteEmployeeAsync(Guid id, CancellationToken ct)
    {
        libraryDbContext.Employees.Remove(new Employee(id));

        await libraryDbContext.SaveChangesAsync(ct);
    }

    public async Task SetManagementClass(Employee employee, SchoolClass @class, CancellationToken ct)
    {
        libraryDbContext.Attach(employee);
        libraryDbContext.Attach(@class);

        employee.SetManagementClass(@class);

        await libraryDbContext.SaveChangesAsync(ct);
    }
}
