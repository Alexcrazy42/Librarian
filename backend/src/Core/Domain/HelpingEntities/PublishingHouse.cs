using Domain.Entities.Books;

namespace Domain.HelpingEntities;

public class PublishingHouse
{
    public static int NameMaxLength = 200;

    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public IReadOnlyCollection<BaseEducationalBook> Books { get; private set; } = new List<BaseEducationalBook>();

    private PublishingHouse()
    { }

    public PublishingHouse(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}
