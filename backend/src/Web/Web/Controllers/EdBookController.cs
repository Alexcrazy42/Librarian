using Domain.Contracts.Requests.EdBooks;
using Domain.Contracts.Responses.EdBooks;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("api/ed-books")]
public class EdBookController : ControllerBase
{
    private readonly IEdBookService edBookService;

	public EdBookController(IEdBookService edBookService)
	{
		this.edBookService = edBookService;
	}

	[HttpGet("get-similar")]
	public async Task<IReadOnlyCollection<BaseEdBookResponse>> GetSimilarEdBookAsync([FromBody] GetSimilarBaseEdBookRequest request, CancellationToken ct)
	{
		throw new NotImplementedException();
	}

	[HttpPost]
	public async Task<EdBookInBalanceResponse> CreateEdBookAsync([FromBody] CreateEdBookRequest request, CancellationToken ct)
	{
		throw new NotImplementedException();
	}
}
