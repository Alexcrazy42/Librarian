using AutoMapper;
using Domain.Contracts.Requests.Rents;
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

    public async Task GetClassRentSituationAsync(Guid classId, CancellationToken cancellationToken)
    {

    }

    public async Task<IActionResult> CreateClassRentEdBooksAsync([FromBody] CreateClassRentEdBookRequest request, CancellationToken cancellationToken)
    {
        var res = await classRentEdBookService.CreateClassRentEdBooksAsync(request, cancellationToken);

        throw new NotImplementedException();
    }
}
