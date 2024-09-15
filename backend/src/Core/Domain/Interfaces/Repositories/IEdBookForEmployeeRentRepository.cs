using Domain.Entities.Rents.People;

namespace Domain.Interfaces.Repositories;

public interface IEdBookForEmployeeRentRepository
{
    public Task<EducationalBookEmployeeRent> CreateEmployeeEdBookRentAsync(EducationalBookEmployeeRent rent, CancellationToken ct);

    public Task<EducationalBookEmployeeRent> UpdateEmployeeEdBookRentAsync(EducationalBookEmployeeRent rent, CancellationToken ct);

    public Task<IReadOnlyCollection<EducationalBookEmployeeRent>> GetEmployeeEdBookRentsWithEmployeeAndBookAsync(IReadOnlyCollection<Guid> ids, CancellationToken ct);

    public Task<EducationalBookEmployeeRent> GetEmployeeEdBookRentAsync(Guid employeeId, Guid edBookInBalanceId, CancellationToken ct);

    public Task<IReadOnlyCollection<EducationalBookEmployeeRent>> GetEmployeeEdBookRentsAsync(Guid employeeId, CancellationToken ct);

    public Task<IReadOnlyCollection<EducationalBookEmployeeRent>> UpdateEmployeeEdBookRentsAsync(IReadOnlyCollection<EducationalBookEmployeeRent> rents, CancellationToken ct);
}