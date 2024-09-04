using AutoMapper;
using Domain.Contracts.Requests.ClassSubjects;
using Domain.Contracts.Responses.ClassSubject;
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
    public async Task<IReadOnlyCollection<ClassSubjectDto>> CreateClassSubjectStructureAsync([FromBody] CreateClassSubjectStructureRequest request, CancellationToken ct)
    {
        var classSubjects = await classSubjectService.CreateClassSubjectStructureAsync(request, ct);

        var classSubjectsDtos = classSubjects
            .GroupBy(x => x.SchoolClass)
            .Select(group => new ClassSubjectDto()
            {
                SchoolClassId = group.Key.Id,
                Number = group.Key.Number,
                Name = group.Key.Name,
                Subjects = group.Select(x => new ClassSubjectResponse()
                {
                    Id = x.Id,
                    SubjectId = x.Subject.Id,
                    Name = x.Subject.Name,
                    Chapters = x.Chapters.Select(x => new ClassSubjectChapterDto()
                    {
                        Id = x.Id,
                        Title = x.Title
                    }).ToList()
                }).ToList()
            }).ToList();

        return classSubjectsDtos;
    }
}
