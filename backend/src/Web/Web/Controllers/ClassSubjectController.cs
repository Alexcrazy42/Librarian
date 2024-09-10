using AutoMapper;
using Domain.Contracts.Requests.ClassSubjects;
using Domain.Contracts.Responses.ClassSubject;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Domain.Contracts.Responses.EdBooks;

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
                    Chapters = x.Chapters.Select(x => new ClassSubjectChapterWithBookDto()
                    {
                        Id = x.Id,
                        Title = x.Title,
                        EdBook = null
                    }).ToList()
                }).ToList()
            }).ToList();

        return classSubjectsDtos;
    }

    [HttpPost("set-ed-book-to-subject-chapters")]
    public async Task<IReadOnlyCollection<ClassSubjectChapterResponse>> SetEdBooksInBalanceToClassSubjectsAsync(
        [FromBody] IReadOnlyCollection<SetEdBookToClassSubjectChapterRequest> request, CancellationToken ct)
    {
        var classSubjectChapterEdBooks = await classSubjectService.SetEdBookToClassSubjectChaptersAsync(request, ct);

        return classSubjectChapterEdBooks.Select(x => new ClassSubjectChapterResponse()
        {
            Id = x.SubjectChapter.Id,
            Title = x.SubjectChapter.Title,
            EdBookInBalance = new EdBookInBalanceResponse()
            {
                Id = x.EdBookInBalance.Id,
                BaseEdBook = new BaseEdBookResponse()
                {
                    Id = x.EdBookInBalance.BaseEducationalBook.Id,
                    Title = x.EdBookInBalance.BaseEducationalBook.Title,
                    PublishingSeries = x.EdBookInBalance.BaseEducationalBook.PublishingSeries,
                    Language = x.EdBookInBalance.BaseEducationalBook.Language,
                    Level = x.EdBookInBalance.BaseEducationalBook.Level,
                    Appointment = x.EdBookInBalance.BaseEducationalBook.Appointment,
                    Chapter = x.EdBookInBalance.BaseEducationalBook.Chapter,
                    StartClass = x.EdBookInBalance.BaseEducationalBook.StartClass,
                    EndClass = x.EdBookInBalance.BaseEducationalBook.EndClass
                },
                Price = x.EdBookInBalance.Price,
                Condition = x.EdBookInBalance.Condition,
                Year = x.EdBookInBalance.Year,
                Note = x.EdBookInBalance.Note,
                InPlaceCount = x.EdBookInBalance.InPlaceCount,
                TotalCount = x.EdBookInBalance.TotalCount,
                SupplyId = x.EdBookInBalance.Supply?.Id,
                GroundId = x.EdBookInBalance.BookOwnerGround?.Id,
                InStock = x.EdBookInBalance.InStock
            }
        }).ToList();
    }
}
