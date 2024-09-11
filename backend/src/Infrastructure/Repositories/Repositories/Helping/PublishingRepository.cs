using Domain.HelpingEntities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Store.Db;

namespace Repositories.Repositories.Helping;

internal class PublishingRepository : IPublishingRepository
{
    private readonly LibraryDbContext libraryDbContext;

    public PublishingRepository(LibraryDbContext libraryDbContext)
    {
        this.libraryDbContext = libraryDbContext;
    }

    public async Task<PublishingHouse> CreatePublishingHouseIfNotExistAsync(string name, CancellationToken ct)
    {
        var house = await libraryDbContext.PublishingHouses
            .FirstOrDefaultAsync(x => x.Name.ToUpper() == name.ToUpper(), ct);

        if (house != null)
        {
            return house;   
        }

        var newHouse = new PublishingHouse(Guid.NewGuid(), name);

        libraryDbContext.PublishingHouses.Add(newHouse);
        await libraryDbContext.SaveChangesAsync(ct);

        return newHouse;
    }

    public async Task<PublishingPlace> CreatePublishingPlaceIfNotExistAsync(string name, CancellationToken ct)
    {
        var place = await libraryDbContext.PublishingPlaces
            .FirstOrDefaultAsync(x => x.Name.ToUpper() == name.ToUpper(), ct);

        if (place != null)
        {
            return place;
        }

        var newPlace = new PublishingPlace(Guid.NewGuid(), name);
        libraryDbContext.PublishingPlaces.Add(newPlace);
        await libraryDbContext.SaveChangesAsync(ct);
        return newPlace;
    }

    public async Task<IReadOnlyCollection<PublishingHouse>> GetPublishingHousesAsync(string partName, CancellationToken ct)
    {
        return await libraryDbContext.PublishingHouses
            .Where(x => x.Name.ToUpper().Contains(partName.ToUpper()))
            .ToListAsync(ct);
    }

    public async Task<IReadOnlyCollection<PublishingPlace>> GetPublishingPlacesAsync(string partName, CancellationToken ct)
    {
        return await libraryDbContext.PublishingPlaces
            .Where(x => x.Name.ToUpper().Contains(partName.ToUpper()))
            .ToListAsync(ct);
    }
}
