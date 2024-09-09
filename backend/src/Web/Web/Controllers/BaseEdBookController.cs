using Domain.Contracts.Requests.EdBooks;
using Domain.Contracts.Responses.EdBooks;
using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("api/base-ed-books")]
public class BaseEdBookController : ControllerBase
{
    private readonly IBaseEdBookRepository baseEdBookRepository;

    public BaseEdBookController(IBaseEdBookRepository baseEdBookRepository)
    {
        this.baseEdBookRepository = baseEdBookRepository;
    }

    [HttpPost("get-familiar")]
    public async Task<IReadOnlyCollection<BaseEdBookResponse>> GetSimilarBookAsync([FromBody] GetSimilarBaseEdBookRequest request, CancellationToken ct)
    {
        var baseEdBooks = await baseEdBookRepository.GetSimilarBookAsync(request, ct);

        return baseEdBooks.Select(x => new BaseEdBookResponse()
        {
            Id = x.Id,
            Title = x.Title,
            PublishingSeries = x.PublishingSeries,
            Language = x.Language,
            Level = x.Level,
            Appointment = x.Appointment,
            Chapter = x.Chapter,
            StartClass = x.StartClass,
            EndClass = x.EndClass
        }).ToList();
    }

    [HttpPost("create-after-not-suit-familiar")]
    public async Task<Guid> CreateBookAfterUserSureWhatAnotherVariantsNotSuitAsync([FromBody] CreateBaseEdBookRequest request, CancellationToken ct)
    {
        return await baseEdBookRepository.CreateBookAfterUserSureWhatAnotherVariantsNotSuitAsync(request, ct);
    }
}
