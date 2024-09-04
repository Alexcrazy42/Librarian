using Domain.Contracts.Requests.ClassSubjects;
using Domain.HelpingEntities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Store.Db;
using System.Security.Cryptography.X509Certificates;

namespace Repositories.Repositories;

internal class SubjectRepository : ISubjectRepository
{
    private readonly LibraryDbContext libraryDbContext;

    public SubjectRepository(LibraryDbContext libraryDbContext)
    {
        this.libraryDbContext = libraryDbContext;
    }

    public async Task<Subject> CreateSubjectIfNotExistsAsync(string name, CancellationToken ct)
    {
        var subject = await libraryDbContext.Subjects
            .FirstOrDefaultAsync(x => x.Name == name, ct);

        if (subject == null)
        {
            var newSubject = new Subject(Guid.NewGuid(), name);

            await libraryDbContext.Subjects.AddAsync(newSubject, ct);

            return newSubject;
        }
        return subject;
    }

    public async Task<IReadOnlyCollection<Subject>> GetFamiliarSubjectsAsync(string partName, CancellationToken ct)
    {
        return await libraryDbContext.Subjects
            .Where(x => x.Name.Contains(partName))
            .ToListAsync(ct);
    }

    public async Task<IReadOnlyCollection<Subject>> GetOrCreateSubjectsAsync(IReadOnlyCollection<CreateSubjectRequest> subjects, CancellationToken ct)
    {
        var ids = subjects.Where(r => r.SubjectId.HasValue).Select(r => r.SubjectId.Value).ToList();
        var names = subjects.Where(r => !string.IsNullOrEmpty(r.SubjectName)).Select(r => r.SubjectName).ToList();

        var existingSubjectsQuery = libraryDbContext.Subjects.AsQueryable();

        if (ids.Any())
        {
            existingSubjectsQuery = existingSubjectsQuery.Where(subject => ids.Contains(subject.Id));
        }

        if (names.Any())
        {
            existingSubjectsQuery = existingSubjectsQuery.Where(subject => names.Contains(subject.Name));
        }

        var existingSubjects = await existingSubjectsQuery.ToListAsync(ct);

        var existingSubjectsLookup = existingSubjects.ToDictionary(s => s.Id, s => s.Name);

        var subjectsToAdd = subjects
            .Where(r => !r.SubjectId.HasValue || !existingSubjectsLookup.ContainsKey(r.SubjectId.Value))
            .Where(r => string.IsNullOrEmpty(r.SubjectName) || !existingSubjectsLookup.Values.Contains(r.SubjectName))
            .Select(r => new Subject(
                id: r.SubjectId ?? Guid.NewGuid(),
                name: r.SubjectName ?? "Unnamed"))
            .ToList();

        if (subjectsToAdd.Any())
        {
            await libraryDbContext.Subjects.AddRangeAsync(subjectsToAdd, ct);
            await libraryDbContext.SaveChangesAsync(ct);
        }

        return await existingSubjectsQuery.ToListAsync(ct);
    }
}
