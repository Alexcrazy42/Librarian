using Domain.Common.Exceptions;
using Domain.Contracts.Requests.EdBooks;
using Domain.Contracts.Responses.EdBooks;
using Domain.Entities.Books;
using Domain.Entities.SchoolStructure;
using Domain.Entities.Supplies;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Store.Db;

namespace Repositories.Repositories;

internal class EdBookInBalanceRepository : IEdBookInBalanceRepository
{
    private readonly LibraryDbContext libraryDbContext;

    public EdBookInBalanceRepository(LibraryDbContext libraryDbContext)
    {
        this.libraryDbContext = libraryDbContext;
    }

    public async Task<EducationalBookInBalance> CreateEdBookInBalanceAsync(CreateEdBookInBalanceRequest request, CancellationToken ct)
    {
        var baseEdBook = new BaseEducationalBook(request.BaseEdBookId);

        var ground = new SchoolGround(request.GroundId);

        var supply = new BookSupply(request.SupplyId);

        libraryDbContext.Attach(baseEdBook);
        libraryDbContext.Attach(ground);
        libraryDbContext.Attach(supply);

        var edBookInBalance = new EducationalBookInBalance(
            id: Guid.NewGuid(),
            baseEducationalBook: baseEdBook,
            price: request.Price,
            condition: request.Condition,
            year: request.Year,
            note: request.Note,
            inPlaceCount: request.Count,
            totalCount: request.Count,
            inStock: true,
            currentschoolGround: ground,
            bookOwnerGround: ground,
            supply: supply
        );

        libraryDbContext.EducationalBooksInBalance.Add(edBookInBalance);

        await libraryDbContext.SaveChangesAsync(ct);

        libraryDbContext.Entry(baseEdBook).State = EntityState.Detached;
        libraryDbContext.Entry(ground).State = EntityState.Detached;
        libraryDbContext.Entry(supply).State = EntityState.Detached;

        var edBookInDb = await libraryDbContext.EducationalBooksInBalance
            .Include(x => x.BaseEducationalBook)
            .Include(x => x.BookOwnerGround)
            .Include(x => x.Supply)
            .FirstOrDefaultAsync(x => x.Id == edBookInBalance.Id, ct)
            ?? throw new NotFoundException("Книга не найдена!");

        return edBookInDb;
    }

    public async Task<EducationalBookInBalance> GetEdBookInBalanceAsync(Guid id, CancellationToken ct)
    {
        return await libraryDbContext.EducationalBooksInBalance
            .Include(x => x.BaseEducationalBook)
            .FirstOrDefaultAsync(x => x.Id == id, ct)
            ?? throw new CommonException("Книга не найдена!");
    }

    public async Task<EducationalBookInBalance> UpdateEdBookInBalanceAsync(EducationalBookInBalance edBookInBalance, CancellationToken ct)
    {
        libraryDbContext.Entry(edBookInBalance).State = EntityState.Modified;

        await libraryDbContext.SaveChangesAsync(ct);

        return edBookInBalance;
    }
}
