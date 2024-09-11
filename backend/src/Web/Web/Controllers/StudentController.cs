using AutoMapper;
using Domain.Common.Exceptions;
using Domain.Contracts.Requests.Students;
using Domain.Contracts.Responses.Students;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace Web.Controllers;

[ApiController]
[Route("api/students")]
public class StudentController : ControllerBase
{
	private readonly IStudentService studentService;
	private readonly IStudentRepository studentRepository;
	private readonly IMapper mapper;

	public StudentController(IStudentService studentService,
		IStudentRepository studentRepository,
		IMapper mapper)
	{
		this.studentService = studentService;
		this.studentRepository = studentRepository;
		this.mapper = mapper;
	}

	[HttpGet("class")]
	public async Task<IReadOnlyCollection<StudentDto>> GetStudentsFromClass(Guid classId, CancellationToken ct)
	{
		var students = await studentRepository.GetStudentsFromClassAsync(classId, ct);

        return students.Select(x => new StudentDto()
        {
            Id = x.Id,
            IsArchived = x.IsArchived,
            Surname = x.Surname,
            Name = x.Name,
            Patronymic = x.Patronymic,
            ClassId = x.SchoolClass?.Id ?? null
        }).ToList();
    }

	[HttpPost]
	public async Task<IReadOnlyCollection<StudentDto>> AddStudentsToClass([FromBody] AddStudentsToClassRequest request, CancellationToken ct)
	{
		var students = await studentService.AddStudentsToClassAsync(request, ct);

		return students.Select(x => new StudentDto()
		{
			Id = x.Id,
			IsArchived = x.IsArchived,
			Surname = x.Surname,
			Name = x.Name,
			Patronymic = x.Patronymic,
			ClassId = x.SchoolClass?.Id ?? null
		}).ToList();
	}

	[HttpPost("transfer-next-year")]
	public async Task<ActionResult> TransferStudentsToYearUpAsync([FromBody] IReadOnlyCollection<TransferStudentsFromOneClassToAnotherRequest> request, CancellationToken ct)
	{
		var (requestValid, errorMessage) = IsClassTransfersHaveValidDependences(request);

		if (!requestValid)
		{
			return BadRequest(errorMessage);
		}

		try
		{
			await studentRepository.TransferStudentsToYearUpAsync(request, ct);
			return Ok("Успешно!");
		}
		catch(CommonException ex)
		{
			return BadRequest(ex.Message);
		}

	}

	[HttpPut("transter-students/{classId}")]
	public async Task TransferStudentsToAnotherClassAsync([FromRoute] Guid classId, [FromBody] IReadOnlyCollection<Guid> studentsIds, CancellationToken ct)
	{
		throw new NotImplementedException();
	}

	private (bool Valid, string Error) IsClassTransfersHaveValidDependences(IReadOnlyCollection<TransferStudentsFromOneClassToAnotherRequest> request)
	{
		// TODO
		return (true, "");
	}
}
