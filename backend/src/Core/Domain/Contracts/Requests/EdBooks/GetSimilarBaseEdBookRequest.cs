using Domain.Enums;

namespace Domain.Contracts.Requests.EdBooks;

public class GetSimilarBaseEdBookRequest
{
    public Guid? AuthorId { get; set; }

    public Guid? EditorId { get; set; }

    public string? Title { get; set; }

    public Guid? PublishingPlaceId { get; set; }

    public Guid? PublishingHouseId { get; set; }

    public int? PublishingSeries { get; set; }

    public Language? Language { get; set; }

    public Level? Level { get; set; }

    public Appointment? Appointment { get; set; }

    public int? Chapter { get; set; }

    public Guid? SubjectId { get; set; }

    public int? StartClass { get; set; }

    public int? EndClass { get; set; }

    public DateOnly? LeaveFromFederalBooksListAt { get; set; }

    public IReadOnlyCollection<Guid> AnotherAuthorsIds { get; set; } = new List<Guid>();
}
