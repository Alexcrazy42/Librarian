using Domain.Contracts.Requests.School;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("api/school")]
public class SchoolController : ControllerBase
{
	private readonly ISchoolService schoolService;

	public SchoolController(ISchoolService schoolService)
	{
		this.schoolService = schoolService;
	}

	[HttpPost]
	public async Task<IActionResult> CreateSchoolStructureAsync(CreateSchoolStructureRequest request, CancellationToken cancellationToken)
	{
		var school = await schoolService.CreateSchoolStructureAsync(request, cancellationToken);

		return Ok(school);
	}
}
