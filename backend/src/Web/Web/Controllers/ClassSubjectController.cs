using AutoMapper;
using Domain.Contracts.Requests.ClassSubject;
using Domain.Contracts.Responses;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("api/class-subjects")]
public class ClassSubjectController : ControllerBase
{
    private readonly IClassSubjectService classSubjectService;
    private readonly IMapper mapper;

    public ClassSubjectController(IClassSubjectService classSubjectService,
        IMapper mapper)
    {
        this.classSubjectService = classSubjectService;
        this.mapper = mapper;
    }

    [HttpPost]
    public async Task<ClassSubjectStructureResponse> CreateClassSubjectStructureAsync([FromBody] CreateClassSubjectStructureRequest request, CancellationToken cancellationToken)
    {
        var classSubjects = await classSubjectService.CreateClassSubjectStructureAsync(request, cancellationToken);

        return mapper.Map<ClassSubjectStructureResponse>(classSubjects);
    }
}
