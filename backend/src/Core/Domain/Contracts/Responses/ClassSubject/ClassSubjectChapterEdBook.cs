using Domain.Contracts.Responses.EdBooks;

namespace Domain.Contracts.Responses.ClassSubject;

public class ClassSubjectChapterResponse
{
    public Guid Id { get; set; }

    public Guid ChapterId { get; set; }

    public string Title { get; set; }

    public EdBookInBalanceResponse EdBookInBalance { get; set; }
}