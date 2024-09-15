using Domain.Common.Exceptions;
using Domain.Entities.Rents.People;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Store.Db;

namespace Repositories.Repositories;

public class EdBookForStudentRentRepository : IEdBookForStudentRentRepository
{
    private readonly LibraryDbContext libraryDbContext;

    public EdBookForStudentRentRepository(LibraryDbContext libraryDbContext)
    {
        this.libraryDbContext = libraryDbContext;
    }

    public async Task<EducationalBookStudentRent> CreateStudentEdBookRentAsync(EducationalBookStudentRent rent, CancellationToken ct)
    {
        libraryDbContext.Attach(rent.Book);
        libraryDbContext.EdBooksStudentsRents.Add(rent);

        await libraryDbContext.SaveChangesAsync(ct);

        return rent;
    }

    public async Task<EducationalBookStudentRent> GetStudentEdBookRentAsync(Guid studentId, Guid edBookInBalanceId, CancellationToken ct)
    {
        return await libraryDbContext.EdBooksStudentsRents
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Student.Id == studentId && x.Book.Id == edBookInBalanceId, ct)
            ?? throw new NotFoundException("Не найдена аренда!");
    }

    public async Task<IReadOnlyCollection<EducationalBookStudentRent>> GetStudentEdBookRentsWithStudentAndBookAsync(IReadOnlyCollection<Guid> ids, CancellationToken ct)
    {
        return await libraryDbContext.EdBooksStudentsRents
            .Include(x => x.Student)
            .Include(x => x.Book)
            .Where(x => ids.Contains(x.Id))
            .ToListAsync(ct);
    }

    public async Task<EducationalBookStudentRent> UpdateStudentEdBookRentAsync(EducationalBookStudentRent rent, CancellationToken ct)
    {
        libraryDbContext.Entry(rent).State = EntityState.Modified;

        await libraryDbContext.SaveChangesAsync(ct);

        return rent;
    }

    public async Task<IReadOnlyCollection<EducationalBookStudentRent>> UpdateStudentEdBookRentsAsync(IReadOnlyCollection<EducationalBookStudentRent> rents, CancellationToken ct)
    {
        libraryDbContext.AttachRange(rents);

        await libraryDbContext.SaveChangesAsync(ct);

        return await libraryDbContext.EdBooksStudentsRents
            .Where(x => rents.Select(x => x.Id).ToList().Contains(x.Id))
            .ToListAsync(ct);
    }
}
