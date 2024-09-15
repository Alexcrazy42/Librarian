using Domain.Contracts.Requests.EdBooks;
using Domain.Contracts.Responses.EdBooks;
using Domain.Entities.Books;
using Domain.Enums;
using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("api/ed-books")]
public class EdBookInBalanceController : ControllerBase
{
	private readonly IEdBookInBalanceRepository edBookRepository;

	public EdBookInBalanceController(IEdBookInBalanceRepository edBookRepository)
	{
		this.edBookRepository = edBookRepository;
	}

	[HttpGet("{id}")]
	public async Task<EdBookInBalanceResponse> GetEdBookInBalanceAsync([FromRoute] Guid id, CancellationToken ct)
	{
		var edBookInBalance = await edBookRepository.GetEdBookInBalanceAsync(id, ct);
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

	[HttpPost]
	public async Task<EdBookInBalanceResponse> CreateEdBookAsync([FromBody] CreateEdBookInBalanceRequest request, CancellationToken ct)
	{
		var edBookInBalance = await edBookRepository.CreateEdBookInBalanceAsync(request, ct);
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

    [HttpPut]
    public async Task<EdBookInBalanceResponse> UpdateEdBookInBalanceAsync([FromBody] UpdateEdBookInBalanceRequest request, CancellationToken ct)
	{
        var edBookInBalanceToUpdate = new EducationalBookInBalanceBuilder(request.Id)
            .SetBaseEducationalBook(request.BaseEdBookId)
            .SetPrice(request.Price)
            .SetCondition(request.Condition)
            .SetYear(request.Year)
            .SetNote(request.Note)
            .Build();


        var updatedEdBookInBalance = new EducationalBookInBalance(request.Id);

		var edBookInBalance = await edBookRepository.UpdateEdBookInBalanceAsync(edBookInBalanceToUpdate, ct);


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

    [HttpDelete("id")]
    public async Task WriteOffEdBookInBalanceAsync(Guid id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    [HttpGet("can-issue-ed-book-in-balance/{edBookInBalanceId}")]
    public async Task<CanIssueEdBookInBalanceResponse> CanIssueEdBookInBalanceAsync([FromRoute] Guid edBookInBalanceId, [FromQuery] int count, CancellationToken ct)
    {
		var edBookInBalance = await edBookRepository.GetEdBookInBalanceAsync(edBookInBalanceId, ct);

		return edBookInBalance.CanIssue(count);
    }
}
