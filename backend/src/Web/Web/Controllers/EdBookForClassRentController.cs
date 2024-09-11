using Domain.Contracts.Responses.EdBookFroClassRent;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("api/ed-book-class-rent")]
public class EdBookForClassRentController : ControllerBase
{
    private readonly IEdBookForClassRentService edBookForClassRentService;

    public EdBookForClassRentController(IEdBookForClassRentService edBookForClassRentService)
    {
        this.edBookForClassRentService = edBookForClassRentService;
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
