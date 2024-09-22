using Domain.Common.Exceptions;
using Domain.Entities.Books;
using Domain.Entities.RentRequests;
using Domain.Entities.Rents.School;
using Domain.Entities.SchoolStructure;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Store.Db;

namespace Repositories.Repositories;

internal class SchoolBookRentRepository : ISchoolBookRentRepository
{
    private readonly LibraryDbContext libraryDbContext;

    public SchoolBookRentRepository(LibraryDbContext libraryDbContext)
    {
        this.libraryDbContext = libraryDbContext;
    }

    public async Task CloseRequestByDebtorAsync(Guid requestId, CancellationToken ct)
    {
        var request = new EducationalBookSchoolRentRequest(requestId);

        request.ResolvedByRequestingSide = true;

        libraryDbContext.Attach(request);
        libraryDbContext.Entry(request).Property(x => x.ResolvedByRequestingSide).IsModified = true;

        await libraryDbContext.SaveChangesAsync(ct);
    }

    public async Task CloseRequestByOwnerAsync(Guid requestId, CancellationToken ct)
    {
        var request = new EducationalBookSchoolRentRequest(requestId);

        request.ResolvedByRequestedSide = true;

        libraryDbContext.Attach(request);
        libraryDbContext.Entry(request).Property(x => x.ResolvedByRequestedSide).IsModified = true;

        await libraryDbContext.SaveChangesAsync(ct);

        libraryDbContext.Entry(request).State = EntityState.Detached;
    }

    public async Task ReceiveBooksByDebtorAsync(EducationalBookSchoolRentRequest request, EducationalBookInBalance newEdbook, 
        EducationalBookSchoolRent schoolRent, CancellationToken ct)
    {
        libraryDbContext.Attach(request);
        
        libraryDbContext.Entry(request).Property(x => x.ReceivedByDebtor).IsModified = true;
        libraryDbContext.Entry(request).Property(x => x.IsArchived).IsModified = true;
        libraryDbContext.Entry(request.Book).Property(x => x.InPlaceCount).IsModified = true;

        libraryDbContext.EducationalBooksInBalance.Add(newEdbook);
        libraryDbContext.EdBookSchoolRents.Add(schoolRent);

        await libraryDbContext.SaveChangesAsync(ct);
    }

    public async Task SendBooksByOwnerAsync(Guid requestId, CancellationToken ct)
    {
        var request = new EducationalBookSchoolRentRequest(requestId);

        request.SendByOwner = true;

        libraryDbContext.Attach(request);
        libraryDbContext.Entry(request).Property(x => x.SendByOwner).IsModified = true;

        await libraryDbContext.SaveChangesAsync(ct);
    }

    public async Task SetVisibleOfRequestAsync(Guid requestId, CancellationToken ct)
    {
        var request = new EducationalBookSchoolRentRequest(requestId);

        request.ViewedUpdatesByRequestedSide = true;

        libraryDbContext.Attach(request);
        libraryDbContext.Entry(request).Property(x => x.ViewedUpdatesByRequestedSide).IsModified = true;

        await libraryDbContext.SaveChangesAsync(ct);
    }

    public async Task SetVisibleOfResponseAsync(Guid requestId, CancellationToken ct)
    {
        var request = new EducationalBookSchoolRentRequest(requestId);

        request.ViewedUpdatesByRequestingSide = true;

        libraryDbContext.Attach(request);
        libraryDbContext.Entry(request).Property(x => x.ViewedUpdatesByRequestingSide).IsModified = true;

        await libraryDbContext.SaveChangesAsync(ct);
    }

    public async Task<EducationalBookSchoolRentRequest> CreateAsync(EducationalBookSchoolRentRequest entity, CancellationToken ct)
    {
        libraryDbContext.Attach(entity.DebtorSchoolGround);
        libraryDbContext.Attach(entity.OwnerSchoolGround);
        libraryDbContext.Attach(entity.CreatedBy);
        libraryDbContext.Attach(entity.Book);

        libraryDbContext.EdBookSchoolRentRequests.Add(entity);

        await libraryDbContext.SaveChangesAsync(ct);

        libraryDbContext.Entry(entity.DebtorSchoolGround).State = EntityState.Detached;
        libraryDbContext.Entry(entity.OwnerSchoolGround).State = EntityState.Detached;
        libraryDbContext.Entry(entity.CreatedBy).State = EntityState.Detached;
        libraryDbContext.Entry(entity.Book).State = EntityState.Detached;

        return await libraryDbContext.EdBookSchoolRentRequests
            .Include(x => x.DebtorSchoolGround)
            .Include(x => x.OwnerSchoolGround)
            .Include(x => x.Book)
            .Include(x => x.CreatedBy)
            .FirstOrDefaultAsync(x => x.Id == entity.Id, ct)
            ?? throw new NotFoundException("Запрос не найден!");
    }

    public async Task<IReadOnlyCollection<EducationalBookSchoolRentRequest>> GetAllReceivedRequestsAsync(Guid groundId, CancellationToken ct)
    {
        return await libraryDbContext.EdBookSchoolRentRequests
            .Include(x => x.DebtorSchoolGround)
            .Include(x => x.OwnerSchoolGround)
            .Include(x => x.Book)
            .Include(x => x.CreatedBy)
            .Where(x => x.OwnerSchoolGround.Id == groundId)
            .ToListAsync(ct);
    }

    public async Task<IReadOnlyCollection<EducationalBookSchoolRentRequest>> GetAllSendedRequests(Guid groundId, CancellationToken ct)
    {
        return await libraryDbContext.EdBookSchoolRentRequests
            .Include(x => x.DebtorSchoolGround)
            .Include(x => x.OwnerSchoolGround)
            .Include(x => x.Book)
                .ThenInclude(book => book.BaseEducationalBook)
            .Include(x => x.Book)
                .ThenInclude(book => book.Supply)
            .Include(x => x.CreatedBy)
            .Where(x => x.DebtorSchoolGround.Id == groundId)
            .ToListAsync(ct);
    }

    public async Task<EducationalBookSchoolRentRequest> GetAsync(Guid id, CancellationToken ct)
    {
        return await libraryDbContext.EdBookSchoolRentRequests
            .Include(x => x.DebtorSchoolGround)
            .Include(x => x.OwnerSchoolGround)
            .Include(x => x.Book)
            .Include(x => x.CreatedBy)
            .FirstOrDefaultAsync(x => x.Id == id, ct)
            ?? throw new NotFoundException("Запрос не найден!");
    }

    

    public async Task<EducationalBookSchoolRentRequestConversationMessage> SendMessageToDebtorRequestAsync(EducationalBookSchoolRentRequestConversationMessage message, CancellationToken ct)
    {
        libraryDbContext.RentRequestMessages.Add(message);
        libraryDbContext.Attach(message.RentRequest);
        libraryDbContext.Entry(message.RentRequest).Property(x => x.RequestStatus).IsModified = true;
        libraryDbContext.Entry(message.RentRequest).Property(x => x.ResolvedByRequestedSide).IsModified = true;
        libraryDbContext.Entry(message.RentRequest).Property(x => x.ResolvedByRequestingSide).IsModified = true;
        libraryDbContext.Entry(message.RentRequest).Property(x => x.ViewedUpdatesByRequestingSide).IsModified = true;

        if (message.RentRequest.OwnerReadyGiveBookCount != null)
        {
            libraryDbContext.Entry(message.RentRequest).Property(x => x.OwnerReadyGiveBookCount).IsModified = true;
        }
        if (message.RentRequest.OwnerReadyToEndRentAt != null)
        {
            libraryDbContext.Entry(message.RentRequest).Property(x => x.OwnerReadyToEndRentAt).IsModified = true;
        }
        

        libraryDbContext.Attach(message.MessageSender);

        await libraryDbContext.SaveChangesAsync(ct);

        return await libraryDbContext.RentRequestMessages
            .Include(x => x.MessageSender)
            .Include(x => x.RentRequest)
            .FirstOrDefaultAsync(x => x.Id == message.Id, ct)
            ?? throw new NotFoundException("Сообщение не найдено!");
    }

    public async Task<EducationalBookSchoolRentRequestConversationMessage> SendMessageToOwnerResponseAsync(EducationalBookSchoolRentRequestConversationMessage message, CancellationToken ct)
    {
        libraryDbContext.RentRequestMessages.Add(message);
        libraryDbContext.Attach(message.RentRequest);
        if (message.RentRequest.RequestingBookCount != 0)
        {

        }

        libraryDbContext.Entry(message.RentRequest).Property(x => x.RequestingBookCount).IsModified = true;
        libraryDbContext.Entry(message.RentRequest).Property(x => x.EndRentAt).IsModified = true;
        libraryDbContext.Entry(message.RentRequest).Property(x => x.ViewedUpdatesByRequestedSide).IsModified = true;
        libraryDbContext.Attach(message.MessageSender);

        await libraryDbContext.SaveChangesAsync(ct);

        return await libraryDbContext.RentRequestMessages
            .Include(x => x.MessageSender)
            .Include(x => x.RentRequest)
            .FirstOrDefaultAsync(x => x.Id == message.Id, ct)
            ?? throw new NotFoundException("Сообщение не найдено!");
    }

    public async Task<EducationalBookInBalance> GetEdBookInBalanceAsync(Guid requestId, CancellationToken ct)
    {
        var rentRequest = await libraryDbContext.EdBookSchoolRentRequests
            .Include(x => x.Book)
                .ThenInclude(book => book.BaseEducationalBook)
            .FirstOrDefaultAsync(x => x.Id == requestId, ct)
            ?? throw new NotFoundException("Запрос не найден!");

        libraryDbContext.Entry(rentRequest).State = EntityState.Detached;

        return rentRequest.Book;
    }

    public async Task<SchoolGround> GetDebtorGroundAsync(Guid requestId, CancellationToken ct)
    {
        var rentRequest = await libraryDbContext.EdBookSchoolRentRequests
            .Include(x => x.DebtorSchoolGround)
            .FirstOrDefaultAsync(x => x.Id == requestId, ct)
            ?? throw new NotFoundException("Запрос не найден!");

        libraryDbContext.Entry(rentRequest).State = EntityState.Detached;

        return rentRequest.DebtorSchoolGround;
    }

    public async Task ChangeBookCountAsync(EducationalBookSchoolRentRequest request, CancellationToken ct)
    {
        libraryDbContext.Attach(request);

        libraryDbContext.Entry(request).Property(x => x.RequestingBookCount).IsModified = true;

        await libraryDbContext.SaveChangesAsync(ct);
    }
}
