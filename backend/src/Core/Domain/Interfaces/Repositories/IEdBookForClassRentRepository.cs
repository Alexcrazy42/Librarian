using Domain.Entities.Rents.People;

namespace Domain.Interfaces.Repositories;

public interface IEdBookForClassRentRepository
{
    public Task<IReadOnlyCollection<EducationalBookStudentRent>> GetEdBookRentsByClassAsync(Guid classId, CancellationToken ct);

    public Task<IReadOnlyCollection<EducationalBookStudentRent>> CreateEdBooksStudentsRentsAsync(IReadOnlyCollection<EducationalBookStudentRent> edBooksStudentsRents, CancellationToken ct);
}
