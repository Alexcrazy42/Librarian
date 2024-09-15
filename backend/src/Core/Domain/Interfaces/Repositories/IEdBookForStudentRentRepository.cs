using Domain.Entities.Rents.People;

namespace Domain.Interfaces.Repositories;

public interface IEdBookForStudentRentRepository
{
    public Task<EducationalBookStudentRent> CreateStudentEdBookRentAsync(EducationalBookStudentRent rent, CancellationToken ct);

    public Task<EducationalBookStudentRent> UpdateStudentEdBookRentAsync(EducationalBookStudentRent rent, CancellationToken ct);

    public Task<IReadOnlyCollection<EducationalBookStudentRent>> GetStudentEdBookRentsWithStudentAndBookAsync(IReadOnlyCollection<Guid> ids, CancellationToken ct);

    public Task<EducationalBookStudentRent> GetStudentEdBookRentAsync(Guid studentId, Guid edBookInBalanceId, CancellationToken ct);

    public Task<IReadOnlyCollection<EducationalBookStudentRent>> UpdateStudentEdBookRentsAsync(IReadOnlyCollection<EducationalBookStudentRent> rents, CancellationToken ct);
}
