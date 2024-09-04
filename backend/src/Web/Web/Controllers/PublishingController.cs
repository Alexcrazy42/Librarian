using Domain.Contracts.Responses.Publishing;
using Domain.HelpingEntities;
using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("api/publishing")]
public class PublishingController : ControllerBase
{
    private readonly IPublishingRepository publishingRepository;

	public PublishingController(IPublishingRepository publishingRepository)
	{
		this.publishingRepository = publishingRepository;
	}

	[HttpGet("place")]
	public async Task<IReadOnlyCollection<PublishingPlaceResponse>> GetPublishingPlaceAsync(string partName, CancellationToken ct)
	{
		var publishingPlaces = await publishingRepository.GetPublishingPlacesAsync(partName, ct);

        return publishingPlaces.Select(x => new PublishingPlaceResponse()
        {
            Id = x.Id,
            Name = x.Name
        }).ToList();
	}

	[HttpPost("place")]
	public async Task<PublishingPlaceResponse> CreatePlaceIfNotExistAsync(string name, CancellationToken ct)
	{
        var publishingPlace = await publishingRepository.CreatePublishingPlaceIfNotExistAsync(name, ct);

        return new PublishingPlaceResponse()
        {
            Id = publishingPlace.Id,
            Name = publishingPlace.Name
        };
    }

    [HttpGet("house")]
    public async Task<IReadOnlyCollection<PublishingHouseResponse>> GetPublishingHouseAsync(string partName, CancellationToken ct)
    {
        var publishingHouses = await publishingRepository.GetPublishingHousesAsync(partName, ct);

        return publishingHouses.Select(x => new PublishingHouseResponse()
        {
            Id = x.Id,
            Name = x.Name
        }).ToList();
    }

    [HttpPost("house")]
    public async Task<PublishingHouseResponse> CreateHouseIfNotExistAsync(string name, CancellationToken ct)
    {
        var publishingHouse = await publishingRepository.CreatePublishingHouseIfNotExistAsync(name, ct);

        return new PublishingHouseResponse()
        {
            Id = publishingHouse.Id,
            Name = publishingHouse.Name
        };
    }
}
