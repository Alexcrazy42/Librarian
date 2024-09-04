using Domain.Contracts.Responses.Subjects;
using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("api/subjects")]
public class SubjectController : ControllerBase
{
    private readonly ISubjectRepository subjectRepository;

	public SubjectController(ISubjectRepository subjectRepository)
	{
		this.subjectRepository = subjectRepository;
	}

	public async Task<IReadOnlyCollection<SubjectResponse>> GetSubjectAsync(string partName, CancellationToken ct)
	{
		var subjects = await subjectRepository.GetFamiliarSubjectsAsync(partName, ct);


		return subjects.Select(subject => new SubjectResponse()
		{
            Id = subject.Id,
            Name = subject.Name
        }).ToList();
	}

	public async Task<SubjectResponse> CreateSubjectIfNotExistAsync(string name, CancellationToken ct)
	{
		var subject = await subjectRepository.CreateSubjectIfNotExistsAsync(name, ct);

        return new SubjectResponse()
        {
            Id = subject.Id,
            Name = subject.Name
        };
    }
}
