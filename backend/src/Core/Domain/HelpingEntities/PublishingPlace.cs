using Domain.Entities.Books;

namespace Domain.HelpingEntities;

public class PublishingPlace
{

    public static int NameMaxLength = 200;

    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public IReadOnlyCollection<BaseEducationalBook> Books { get; private set; } = new List<BaseEducationalBook>();

    private PublishingPlace()
    { }

    public PublishingPlace(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}
