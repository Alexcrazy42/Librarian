using Domain.Contracts.Responses.EdBooks;

namespace Domain.Contracts.Responses.ClassSubject;

public class UpdateSubjectChapterEdBookResponse
{
    public Guid Id { get; set; }

    public EdBookInBalanceResponse EdBookInBalance { get; set; }
}
