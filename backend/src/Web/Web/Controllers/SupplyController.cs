using Domain.Contracts.Requests.Supplies;
using Domain.Contracts.Responses.EdBooks;
using Domain.Contracts.Responses.Supplies;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("api/supplies")]
public class SupplyController : ControllerBase
{
    private readonly ISupplyService supplyService;
    private readonly ISupplyRepository supplyRepository;

    public SupplyController(ISupplyService supplyService,
        ISupplyRepository supplyRepository)
    {
        this.supplyService = supplyService;
        this.supplyRepository = supplyRepository;
    }

    [HttpGet]
    public async Task<BookSupplyResponse> GetBookSupplyAsync(Guid id, CancellationToken ct)
    {
        var supply = await supplyRepository.GetBookSupplyAsync(id, ct);

        return new BookSupplyResponse
        {
            Id = supply.Id,
            SupplyDate = supply.SupplyDate,
            Supplier = supply.Supplier,
            InvoiceNumber = supply.InvoiceNumber,
            FullFilled = supply.FullFilled,
            EdBooks = supply.EdBooks.Select(x => new EdBookInBalanceResponse()
            {
                Id = x.Id, 
                BaseEdBook = new BaseEdBookResponse()
                {
                    Id = x.BaseBook.Id,
                    Title = x.BaseEducationalBook.Title,
                    PublishingSeries = x.BaseEducationalBook.PublishingSeries,
                    Language = x.BaseEducationalBook.Language,
                    Level = x.BaseEducationalBook.Level,
                    Appointment = x.BaseEducationalBook.Appointment,
                    Chapter = x.BaseEducationalBook.Chapter,
                    StartClass = x.BaseEducationalBook.StartClass,
                    EndClass = x.BaseEducationalBook.EndClass
                },
                Price = x.Price,
                Condition = x.Condition,
                Year = x.Year,
                InPlaceCount = x.InPlaceCount,
                TotalCount = x.TotalCount,
                SupplyId = supply.Id,
                GroundId = x.CurrentSchoolGround.Id,
                InStock = x.InStock
            }).ToList()
        };
    }

    [HttpPost]
    public async Task<Guid> CreateBookSupplyAsync([FromBody] CreateBookSupplyRequest request, CancellationToken ct)
    {
        return await supplyService.CreateSupplyAsync(request, ct);
    }

    [HttpPut("fullfill-supply")]
    public async Task EndSupplyFillingAsync(Guid supplyId, CancellationToken ct)
    {
        await supplyRepository.EndFillingSupplyAsync(supplyId, ct);
    }
}