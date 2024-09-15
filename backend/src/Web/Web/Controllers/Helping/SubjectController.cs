using Domain.Contracts.Responses.Subjects;
using Domain.Interfaces.Repositories.Helping;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Helping;

[ApiController]
[Route("api/subjects")]
public class SubjectController : ControllerBase
{
    private readonly ISubjectRepository subjectRepository;

    public SubjectController(ISubjectRepository subjectRepository)
    {
        this.subjectRepository = subjectRepository;
    }

    [HttpGet]
    public async Task<IReadOnlyCollection<SubjectResponse>> GetSubjectAsync(string partName, CancellationToken ct)
    {
        var subjects = await subjectRepository.GetFamiliarSubjectsAsync(partName, ct);


        return subjects.Select(subject => new SubjectResponse()
        {
            Id = subject.Id,
            Name = subject.Name
        }).ToList();
    }

    [HttpPost]
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
