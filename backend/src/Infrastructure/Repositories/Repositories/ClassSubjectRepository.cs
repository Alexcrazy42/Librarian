using Domain.Entities.Subjects;
using Domain.Interfaces.Repositories;
using Store.Db;

namespace Repositories.Repositories;

internal class ClassSubjectRepository : IClassSubjectRepository
{
    private readonly LibraryDbContext libraryDbContext;

    public ClassSubjectRepository(LibraryDbContext libraryDbContext)
    {
        this.libraryDbContext = libraryDbContext;
    }

    public async Task<IReadOnlyCollection<ClassSubject>> CreateClassSubjectStructureAsync(IReadOnlyCollection<ClassSubject> classSubjects, CancellationToken ct)
    {
        libraryDbContext.ClassSubjects
            .AddRange(classSubjects);

        await libraryDbContext.SaveChangesAsync();

        return classSubjects;
    }
}
