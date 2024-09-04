using AutoMapper;
using Domain.Contracts.Requests.School;
using Domain.Contracts.Responses.School;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

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
}
