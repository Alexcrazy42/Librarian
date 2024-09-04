using Domain.Contracts.Requests.ClassSubjects;
using Domain.Entities.Subjects;

namespace Domain.Interfaces.Services;

public interface IClassSubjectService
{
    public Task<IReadOnlyCollection<ClassSubject>>  CreateClassSubjectStructureAsync(CreateClassSubjectStructureRequest request, CancellationToken ct);
}
