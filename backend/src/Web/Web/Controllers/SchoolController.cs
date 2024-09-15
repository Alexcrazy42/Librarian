using AutoMapper;
using Domain.Common;
using Domain.Contracts.Requests.School;
using Domain.Contracts.Responses.School;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Web.Controllers;

[ApiController]
[Route("api/school")]
public class SchoolController : ControllerBase
{
	private readonly ISchoolService schoolService;
	private readonly ISchoolRepository schoolRepository;
	private readonly IMapper mapper;

	public SchoolController(ISchoolService schoolService,
		ISchoolRepository schoolRepository,
		IMapper mapper)
	{
		this.schoolService = schoolService;
		this.schoolRepository = schoolRepository;
		this.mapper = mapper;
	}

	[HttpGet]
	public async Task<SchoolResponse> GetSchoolAsync(Guid schoolId, CancellationToken ct)
	{
		var school = await schoolRepository.GetById(schoolId, ct);

		return mapper.Map<SchoolResponse>(school);
	}

	[HttpPost]
	public async Task<SchoolResponse> CreateSchoolStructureAsync(CreateSchoolStructureRequest request, CancellationToken ct)
	{
		var school = await schoolService.CreateSchoolStructureAsync(request, ct);

		return mapper.Map<SchoolResponse>(school);
	}

	[HttpPut("school")]
	public async Task<SchoolResponse> UpdateSchoolAsync([FromBody] UpdateSchoolRequest request, CancellationToken ct)
	{
		var updatedSchool = await schoolRepository.UpdateSchoolAsync(request, ct);

		return mapper.Map<SchoolResponse>(updatedSchool);
	}

	[HttpPut("ground")]
	public async Task<SchoolGroundResponse> UpdateGroundAsync([FromBody] UpdateSchoolGroundRequest request, CancellationToken ct)
	{
		var updatedGround = await schoolRepository.UpdateGroundAsync(request, ct);

		return mapper.Map<SchoolGroundResponse>(updatedGround);
	}

	[HttpPut("librarian")]
	public async Task<LibrarianResponse> UpdateLibrarianAsync([FromBody] UpdateLibrarianRequest request, CancellationToken ct)
	{
		var updatedLibrarian = await schoolRepository.UpdateLibrarianAsync(request, ct);

		return mapper.Map<LibrarianResponse>(updatedLibrarian);
	}
}
