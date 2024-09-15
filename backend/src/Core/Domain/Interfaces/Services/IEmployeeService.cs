namespace Domain.Interfaces.Services;

public interface IEmployeeService
{
    public Task MakeClassManagerAsync(Guid id, Guid classId, CancellationToken ct);

    public Task DeleteEmployeeAsync(Guid id, CancellationToken ct);
}
