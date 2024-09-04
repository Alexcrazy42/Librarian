using Domain.Entities.SchoolStructure;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Store.Db;
using System.Collections.Immutable;

namespace Repositories.Repositories;

internal class StudentRepository : IStudentRepository
{
    private readonly LibraryDbContext libraryDbContext;

    public StudentRepository(LibraryDbContext libraryDbContext)
    {
        this.libraryDbContext = libraryDbContext;
    }

    public async Task<IReadOnlyCollection<Student>> AddStudentsToClassAsync(IReadOnlyCollection<Student> students, CancellationToken ct)
    {
        libraryDbContext.Students.AddRange(students);

        await libraryDbContext.SaveChangesAsync(ct);

        return students;
    }

    public async Task<IReadOnlyCollection<Student>> GetStudentsFromClassAsync(Guid classId, CancellationToken ct)
    {
        // TODO: из-за отсутствия навигационных полей мы делаем JOIN на другую таблицу, чтобы это избежать захардкодил sql
        return await libraryDbContext.Students
            .FromSqlRaw($"SELECT s.\"Id\", s.\"Ground_id\", s.\"IsArchived\", s.name, s.patronymic, s.surname, s.class_id, s.school_id\r\n " +
                        $"FROM students AS s " +
                        $"WHERE s.class_id = '{classId}'")
            .ToListAsync(ct);
    }
}
