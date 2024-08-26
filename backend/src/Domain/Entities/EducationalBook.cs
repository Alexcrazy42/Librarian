using Domain.HelpingEntities;

namespace Domain.Entities;

public sealed class EducationalBook
{
    public Guid Id { get; private set; }

    public BookAuthor Author { get; set; }
}
