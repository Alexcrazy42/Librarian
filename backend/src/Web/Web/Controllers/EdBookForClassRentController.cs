using Domain.Contracts.Responses.EdBookForClassRent;
using Domain.Contracts.Responses.EdBooks;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("api/ed-book-class-rent")]
public class EdBookForClassRentController : ControllerBase
{
    private readonly IEdBookForClassRentService edBookForClassRentService;
    private readonly IEdBookForClassRentRepository edBookForClassRentRepository;

    public EdBookForClassRentController(IEdBookForClassRentService edBookForClassRentService, 
        IEdBookForClassRentRepository edBookForClassRentRepository)
    {
        this.edBookForClassRentService = edBookForClassRentService;
        this.edBookForClassRentRepository = edBookForClassRentRepository;
    }

    [HttpGet("{classId}")]
    public async Task<IReadOnlyCollection<GetClassEdBookRentsResponse>> GetEdBookRentsByClassAsync([FromRoute] Guid classId, CancellationToken ct)
    {
        var rents = await edBookForClassRentRepository.GetEdBookRentsByClassAsync(classId, ct);

        return rents.Select(x => new GetClassEdBookRentsResponse()
        {
            Id = x.Id,
            StudentId = x.Student.Id,
            EdBook = new EdBookInBalanceResponse()
            {
                Id = x.Book.Id,
                BaseEdBook = new BaseEdBookResponse()
                {
                    Id = x.Book.BaseEducationalBook.Id,
                    Title = x.Book.BaseEducationalBook.Title,
                    PublishingSeries = x.Book.BaseEducationalBook.PublishingSeries,
                    Chapter = x.Book.BaseEducationalBook.Chapter,
                    StartClass = x.Book.BaseEducationalBook.StartClass,
                    EndClass = x.Book.BaseEducationalBook.EndClass
                },
                Price = x.Book.Price,
                Condition = x.Book.Condition,
                Year = x.Book.Year,
                InPlaceCount = x.Book.InPlaceCount,
                TotalCount = x.Book.TotalCount
            },
            Count = x.Count,
            IsOverdue = x.IsOverdue,
            StartDate = x.StartDate,
            EndDate = x.EndDate
        }).ToList();
    }

    [HttpPost("{classId}/{subjectChapterId}")]
    public async Task<IReadOnlyCollection<StudentEdBookInBalanceRentResponse>> IssueEdBooksToClassBySubjectChapterAsync([FromQuery] DateOnly rentUntil, [FromRoute] Guid classId, [FromRoute] Guid subjectChapterId, CancellationToken ct)
    {
        var studentBookRents = await edBookForClassRentService.IssueEdBooksToClassBySubjectChapterAsync(classId, subjectChapterId, rentUntil, ct);

        return studentBookRents.Select(x => new StudentEdBookInBalanceRentResponse()
        {
            Id = x.Id,
            StudentId = x.Student.Id,
            EdBookInBalanceId = x.Book.Id,
            Count = x.Count,
            IsOverdue = x.IsOverdue,
            StartDate = x.StartDate,
            EndDate = x.EndDate
        }).ToList();
    }
}
