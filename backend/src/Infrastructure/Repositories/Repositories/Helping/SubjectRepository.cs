using Domain.Contracts.Requests.ClassSubjects;
using Domain.HelpingEntities;
using Domain.Interfaces.Repositories.Helping;
using Microsoft.EntityFrameworkCore;
using Store.Db;
using System.Security.Cryptography.X509Certificates;

namespace Repositories.Repositories.Helping;

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

            libraryDbContext.Subjects.Add(newSubject);
            await libraryDbContext.SaveChangesAsync(ct);

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
}
