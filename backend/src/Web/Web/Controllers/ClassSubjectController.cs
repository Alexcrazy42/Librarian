using AutoMapper;
using Domain.Contracts.Requests.ClassSubjects;
using Domain.Contracts.Responses.ClassSubject;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Domain.Contracts.Responses.EdBooks;
using Domain.Interfaces.Repositories;
using Domain.Contracts.Responses.Subjects;

namespace Web.Controllers;

[ApiController]
[Route("api/class-subjects")]
public class ClassSubjectController : ControllerBase
{
    private readonly IClassSubjectService classSubjectService;
    private readonly IClassSubjectRepository classSubjectRepository;
    private readonly IMapper mapper;

    public ClassSubjectController(IClassSubjectService classSubjectService,
        IClassSubjectRepository classSubjectRepository,
        IMapper mapper)
    {
        this.classSubjectService = classSubjectService;
        this.classSubjectRepository = classSubjectRepository;
        this.mapper = mapper;
    }

    [HttpGet("/{classId}")]
    public async Task<IReadOnlyCollection<ClassSubjectDto>> GetSchoolSubjectStructureForClassAsync([FromRoute] Guid classId, CancellationToken ct)
    {
        var classSubjects = await classSubjectRepository.GetClassSubjectStructureForClassAsync(classId, ct);

        return classSubjects
            .GroupBy(x => x.SchoolClass)
            .Select(schoolClass => new ClassSubjectDto()
            {
                SchoolClassId = schoolClass.Key.Id,
                Number = schoolClass.Key.Number,
                Name = schoolClass.Key.Name,
                Subjects = schoolClass.Select(subject => new ClassSubjectResponse()
                {
                    Id = subject.Id,
                    SubjectId = subject.Subject.Id,
                    Name = subject.Subject.Name,
                    Chapters = subject.Chapters.Select(chapter => new ClassSubjectChapterWithBookDto()
                    {
                        Id = chapter.Id,
                        Title = chapter.Title,
                        EdBooks = chapter.EdBooks
                            .Where(edBook => edBook != null)
                            .Select(edBook => new EdBookInBalanceResponse()
                            {
                                // TODO: и в остальных местах тоже
                                //Id = edBook.EdBookInBalance.Id,
                                //BaseEdBook = new BaseEdBookResponse()
                                //{
                                //    Id = edBook.EdBookInBalance.BaseEducationalBook.Id,
                                //    Title = edBook.EdBookInBalance.BaseEducationalBook.Title,
                                //    PublishingSeries = edBook.EdBookInBalance.BaseEducationalBook.PublishingSeries,
                                //    Language = edBook.EdBookInBalance.BaseEducationalBook.Language,
                                //    Level = edBook.EdBookInBalance.BaseEducationalBook.Level,
                                //    Appointment = edBook.EdBookInBalance.BaseEducationalBook.Appointment,
                                //    Chapter = edBook.EdBookInBalance.BaseEducationalBook.Chapter,
                                //    StartClass = edBook.EdBookInBalance.BaseEducationalBook.StartClass,
                                //    EndClass = edBook.EdBookInBalance.BaseEducationalBook.EndClass
                                //},
                                //Price = edBook.EdBookInBalance.Price,
                                //Condition = edBook.EdBookInBalance.Condition,
                                //Year = edBook.EdBookInBalance.Year,
                                //Note = edBook.EdBookInBalance.Note,
                                //InPlaceCount = edBook.EdBookInBalance.TotalCount,
                                //TotalCount = edBook.EdBookInBalance.TotalCount,
                                //InStock = edBook.EdBookInBalance.InStock
                            })
                            .ToList()
                    }).ToList()
                }).ToList()
            })
            .ToList();
    }

    [HttpGet("subject-chapter-ed-books/{}")]
    public async Task<IReadOnlyCollection<EdBookInBalanceResponse>> GetEdBooksInBalanceWhatMatchToBaseEdBookInChapterAsync([FromRoute] Guid subjectChapterId, CancellationToken ct)
    {
        throw new NotImplementedException();
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
                        EdBooks = null
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
            Id = x.Id,
            ChapterId = x.SubjectChapter.Id,
            Title = x.SubjectChapter.Title,
            EdBookInBalance = new EdBookInBalanceResponse()
            {
                //Id = x.EdBookInBalance.Id,
                //BaseEdBook = new BaseEdBookResponse()
                //{
                //    Id = x.EdBookInBalance.BaseEducationalBook.Id,
                //    Title = x.EdBookInBalance.BaseEducationalBook.Title,
                //    PublishingSeries = x.EdBookInBalance.BaseEducationalBook.PublishingSeries,
                //    Language = x.EdBookInBalance.BaseEducationalBook.Language,
                //    Level = x.EdBookInBalance.BaseEducationalBook.Level,
                //    Appointment = x.EdBookInBalance.BaseEducationalBook.Appointment,
                //    Chapter = x.EdBookInBalance.BaseEducationalBook.Chapter,
                //    StartClass = x.EdBookInBalance.BaseEducationalBook.StartClass,
                //    EndClass = x.EdBookInBalance.BaseEducationalBook.EndClass
                //},
                //Price = x.EdBookInBalance.Price,
                //Condition = x.EdBookInBalance.Condition,
                //Year = x.EdBookInBalance.Year,
                //Note = x.EdBookInBalance.Note,
                //InPlaceCount = x.EdBookInBalance.InPlaceCount,
                //TotalCount = x.EdBookInBalance.TotalCount,
                //SupplyId = x.EdBookInBalance.Supply?.Id,
                //GroundId = x.EdBookInBalance.BookOwnerGround?.Id,
                //InStock = x.EdBookInBalance.InStock
            }
        }).ToList();
    }

    [HttpPut("class-subjects")]
    public async Task<IReadOnlyCollection<UpdateClassSubjectResponse>> UpdateClassSubjectsAsync([FromBody] IReadOnlyCollection<UpdateClassSubjectRequest> requests, CancellationToken ct)
    {
        var updates = await classSubjectRepository.UpdateClassSubjectsAsync(requests, ct);

        return updates
            .Select(x => new UpdateClassSubjectResponse()
            {
                Id = x.Id,
                Subject = new SubjectResponse()
                {
                    Id = x.Subject.Id,
                    Name = x.Subject.Name
                }
            }).ToList();
    }

    [HttpPut("subject-chapters")]
    public async Task<IReadOnlyCollection<UpdateSubjectChapterResponse>> UpdateSubjectChaptersAsync([FromBody] IReadOnlyCollection<UpdateSubjectChapterRequest> requests, CancellationToken ct)
    {
        var updates = await classSubjectRepository.UpdateClassSubjectChaptersAsync(requests, ct);

        return updates.Select(x => new UpdateSubjectChapterResponse()
        {
            Id = x.Id,
            Title = x.Title
        }).ToList();
    }

    [HttpPut("subject-chapter-ed-book")]
    public async Task<IReadOnlyCollection<UpdateSubjectChapterEdBookResponse>> UpdateSubjectChapterEdBooksAsync([FromBody] IReadOnlyCollection<UpdateSubjectChapterEdBookRequest> requests, CancellationToken ct)
    {
        var updates = await classSubjectRepository.UpdateSubjectChapterEdBookAsync(requests, ct);

        return updates.Select(x => new UpdateSubjectChapterEdBookResponse()
        {
            Id = x.Id,
            EdBookInBalance = new EdBookInBalanceResponse()
            {
                //Id = x.EdBookInBalance.Id,
                //BaseEdBook = new BaseEdBookResponse()
                //{
                //    Id = x.EdBookInBalance.BaseEducationalBook.Id,
                //    Title = x.EdBookInBalance.BaseEducationalBook.Title,
                //    PublishingSeries = x.EdBookInBalance.BaseEducationalBook.PublishingSeries,
                //    Language = x.EdBookInBalance.BaseEducationalBook.Language,
                //    Level = x.EdBookInBalance.BaseEducationalBook.Level,
                //    Appointment = x.EdBookInBalance.BaseEducationalBook.Appointment,
                //    Chapter = x.EdBookInBalance.BaseEducationalBook.Chapter,
                //    StartClass = x.EdBookInBalance.BaseEducationalBook.StartClass,
                //    EndClass = x.EdBookInBalance.BaseEducationalBook.EndClass
                //},
                //Price = x.EdBookInBalance.Price,
                //Condition = x.EdBookInBalance.Condition,
                //Year = x.EdBookInBalance.Year,
                //Note = x.EdBookInBalance.Note,
                //InPlaceCount = x.EdBookInBalance.InPlaceCount,
                //TotalCount = x.EdBookInBalance.TotalCount,
                //SupplyId = x.EdBookInBalance.Supply?.Id,
                //GroundId = x.EdBookInBalance.BookOwnerGround?.Id,
                //InStock = x.EdBookInBalance.InStock
            }
        }).ToList();
    }
}
