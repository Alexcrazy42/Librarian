using Domain.Common.Exceptions;
using Domain.Contracts.Requests.Students;
using Domain.Entities.SchoolStructure;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Store.Db;
using System.Text;

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
        // TODO: из-за отсутствия навигационных полей мы делаем JOIN на другую таблицу
        return await libraryDbContext.Students
            .Where(x => x.SchoolClass.Id == classId)
            .Include(x => x.SchoolClass)
            .ToListAsync(ct);
    }

    public async Task TransferStudentsToYearUpAsync(IReadOnlyCollection<TransferStudentsFromOneClassToAnotherRequest> request, CancellationToken ct)
    {
        var sqlBuilder = new StringBuilder("UPDATE public.students SET class_id = CASE class_id\n");

        foreach (var transfer in request)
        {
            sqlBuilder.AppendLine($"WHEN '{transfer.OldClass}' THEN '{transfer.NewClass}'");
        }

        sqlBuilder.AppendLine("ELSE class_id END;");

        try
        {
            await libraryDbContext.Database.ExecuteSqlRawAsync(sqlBuilder.ToString(), ct);
        }
        catch (OperationCanceledException)
        {
            throw new CommonException("Что-то пошло не так!");
        }
    }
}
