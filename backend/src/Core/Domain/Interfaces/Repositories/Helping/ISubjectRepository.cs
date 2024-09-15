using Domain.Contracts.Requests.ClassSubjects;
using Domain.HelpingEntities;

namespace Domain.Interfaces.Repositories.Helping;

public interface ISubjectRepository
{
    public Task<IReadOnlyCollection<Subject>> GetOrCreateSubjectsAsync(IReadOnlyCollection<CreateSubjectRequest> subjects, CancellationToken ct);

    public Task<IReadOnlyCollection<Subject>> GetFamiliarSubjectsAsync(string partName, CancellationToken ct);

    public Task<Subject> CreateSubjectIfNotExistsAsync(string name, CancellationToken ct);
}
