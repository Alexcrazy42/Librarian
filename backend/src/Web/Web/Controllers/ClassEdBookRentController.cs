using AutoMapper;
using Domain.Contracts.Requests.Rents;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("api/class-ed-book-rents")]
public class ClassEdBookRentController
{
    private readonly IClassRentEdBookService classRentEdBookService;
    private readonly IMapper mapper;

    public ClassEdBookRentController(IClassRentEdBookService classRentEdBookService,
        IMapper mapper)
    {
        this.classRentEdBookService = classRentEdBookService;
        this.mapper = mapper;
    }

    //public async Task GetClassRentSituationAsync(Guid classId, CancellationToken ct)
    //{

    //}

    //public async Task<IActionResult> CreateClassRentEdBooksAsync([FromBody] CreateClassRentEdBookRequest request, CancellationToken ct)
    //{
    //    var res = await classRentEdBookService.CreateClassRentEdBooksAsync(request, ct);

    //    throw new NotImplementedException();
    //}
}
