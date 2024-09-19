using Domain.Entities.RentRequests;
using Domain.Interfaces.Repositories;
using Store.Db;

namespace Repositories.Repositories;

class SchoolBookRentMessageRepository : ISchoolBookRentMessageRepository
{
    private readonly LibraryDbContext libraryDbContext;

    public SchoolBookRentMessageRepository(LibraryDbContext libraryDbContext)
    {
        this.libraryDbContext = libraryDbContext;
    }

    public async Task VisibleMessagesAsync(IReadOnlyCollection<Guid> messageIds, CancellationToken ct)
    {
        foreach (var messageId in messageIds)
        {
            var message = new EducationalBookSchoolRentRequestConversationMessage(messageId);
            libraryDbContext.Attach(message);

            message.ViewedByReveiver = true;
            libraryDbContext.Entry(message).Property(x => x.ViewedByReveiver).IsModified = true;
        }

        await libraryDbContext.SaveChangesAsync(ct);
    }
}
