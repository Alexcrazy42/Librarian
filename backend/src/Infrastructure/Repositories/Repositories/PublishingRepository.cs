using Domain.HelpingEntities;
using Domain.Interfaces.Repositories;
using Store.Db;

namespace Repositories.Repositories;

internal class PublishingRepository : IPublishingRepository
{
    private readonly LibraryDbContext libraryDbContext;

    public PublishingRepository(LibraryDbContext libraryDbContext)
    {
        this.libraryDbContext = libraryDbContext;
    }

    public Task<PublishingHouse> CreatePublishingHouseIfNotExistAsync(string name, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<PublishingPlace> CreatePublishingPlaceIfNotExistAsync(string name, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<PublishingHouse>> GetPublishingHousesAsync(string partName, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<PublishingPlace>> GetPublishingPlacesAsync(string partName, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
