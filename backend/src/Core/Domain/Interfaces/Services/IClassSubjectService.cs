using Domain.Contracts.Requests.ClassSubjects;

namespace Domain.Interfaces.Services;

public interface IClassSubjectService
{
    public Task<IReadOnlyCollection<Entities.Subjects.ClassSubject>>  CreateClassSubjectStructureAsync(CreateClassSubjectStructureRequest request, CancellationToken cancellationToken);
}
