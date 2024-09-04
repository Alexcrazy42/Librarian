using Domain.HelpingEntities;

namespace Domain.Interfaces.Repositories;

public interface IPublishingRepository
{
    public Task<IReadOnlyCollection<PublishingHouse>> GetPublishingHousesAsync(string partName, CancellationToken ct);

    public Task<IReadOnlyCollection<PublishingPlace>> GetPublishingPlacesAsync(string partName, CancellationToken ct);


    public Task<PublishingHouse> CreatePublishingHouseIfNotExistAsync(string name, CancellationToken ct);

    public Task<PublishingPlace> CreatePublishingPlaceIfNotExistAsync(string name, CancellationToken ct);
}
