using AutoMapper;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces.Repositories;
using Domain.Contracts.Requests.ClassSubjects;
using Domain.Contracts.Requests.Umk;
using Domain.Contracts.Responses.EdBooks;
using Domain.Contracts.Responses.Umk;

namespace Web.Controllers.Umk;

[ApiController]
[Route("api/umk")]
public class UmkController : ControllerBase
{
    private readonly IUmkService umkService;
    private readonly IUmkRepository umkRepository;
    private readonly IMapper mapper;

    public UmkController(IUmkService umkService,
        IUmkRepository umkRepository,
        IMapper mapper)
    {
        this.umkService = umkService;
        this.umkRepository = umkRepository;
        this.mapper = mapper;
    }

    [HttpGet("{groundId}")]
    public Task<UmkStructureForGroundResponse> GetUmkStructureAsync(Guid groundId, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    [HttpGet("{chapterId}")]
    public Task<IReadOnlyCollection<EdBookInBalanceResponse>> GetEdBooksInBalanceAttachedToChapterAsync(Guid chapterId, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public IActionResult CreateUmkStructureAsync([FromBody] CreateUmkStructureRequest request, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    [HttpPost("subject-to-umk-class")]
    public Task<Guid> AddSubjectToUmkClassAsync([FromBody] AddSubjectToUmkClassRequest request, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("subject-to-umk-class/{classSubjectId}")]
    public IActionResult DeleteSubjectToUmkClassAsync([FromRoute] Guid classSubjectId, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    [HttpPost("subject-chapter-to-umk-class")]
    public Task<Guid> AddSubjectChapterToUmkClassAsync([FromBody] AddSubjectChapterToClassSubjectRequest request, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("delete-subject-chapter-to-umk-class/{chapterId}")]
    public IActionResult DeleteSubjectChapterToUmkClassAsync([FromRoute] Guid chapterId, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    [HttpPost("attach-ed-books-to-chapter")]
    public IActionResult AttachEdBooksInBalanceToChapterAsync([FromBody] AttachEdBooksInBalanceToChapterRequest request, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("delete-ed-book-from-chapter")]
    public IActionResult DeleteEdBookFromChapterAsync([FromBody] DeleteEdBookInBalanceFromChapterRequest request, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
