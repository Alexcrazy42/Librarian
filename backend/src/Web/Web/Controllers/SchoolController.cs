using AutoMapper;
using Domain.Contracts.Requests.School;
using Domain.Contracts.Responses;
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
	public async Task<SchoolResponse> GetSchoolAsync(Guid schoolId, CancellationToken cancellationToken)
	{
		var school = await schoolRepository.GetById(schoolId, cancellationToken);

		return mapper.Map<SchoolResponse>(school);
	}

	[HttpPost]
	public async Task<SchoolResponse> CreateSchoolStructureAsync(CreateSchoolStructureRequest request, CancellationToken cancellationToken)
	{
		var school = await schoolService.CreateSchoolStructureAsync(request, cancellationToken);

		return mapper.Map<SchoolResponse>(school);
	}
}
