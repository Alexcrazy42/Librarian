using Domain.Contracts.Requests.EdBooks;
using Domain.Contracts.Responses.EdBooks;
using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Web.Controllers;

[ApiController]
[Route("api/ed-books")]
public class EdBookController : ControllerBase
{
	private readonly IEdBookRepository edBookRepository;

	public EdBookController(IEdBookRepository edBookRepository)
	{
		this.edBookRepository = edBookRepository;
	}

	[HttpPost]
	public async Task<EdBookInBalanceResponse> CreateEdBookAsync([FromBody] CreateEdBookRequest request, CancellationToken ct)
	{
		var edBookInBalance = await edBookRepository.CreateEdBookAsync(request, ct);
		var baseEdBook = edBookInBalance.BaseEducationalBook;

		return new EdBookInBalanceResponse()
		{
			Id = edBookInBalance.Id,
			BaseEdBook = new BaseEdBookResponse()
			{
				Id = baseEdBook.Id,
				Title = baseEdBook.Title,
				PublishingSeries = baseEdBook.PublishingSeries,
				Language = baseEdBook.Language,
				Level = baseEdBook.Level,
				Appointment = baseEdBook.Appointment,
				Chapter = baseEdBook.Chapter,
				StartClass = baseEdBook.StartClass,
				EndClass = baseEdBook.EndClass
            },
			Price = edBookInBalance.Price,
			Condition = edBookInBalance.Condition,
			Year = edBookInBalance.Year,
			Note = edBookInBalance.Note,
			InPlaceCount = edBookInBalance.InPlaceCount,
			TotalCount = edBookInBalance.TotalCount,
			SupplyId = edBookInBalance.Supply?.Id,
			GroundId = edBookInBalance.BookOwnerGround?.Id,
			InStock = edBookInBalance.InStock
		};
	}
}
