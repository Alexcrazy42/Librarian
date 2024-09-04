using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("api/school-classes")]
public class SchoolClassController
{
    private readonly IMapper mapper;

	public SchoolClassController(IMapper mapper)
	{
		this.mapper = mapper;
	}

	//public async Task<IActionResult> TransferStudentsToNextYear(Guid groundId, CancellationToken ct)
	//{
	//	throw new NotImplementedException();
	//}
}
