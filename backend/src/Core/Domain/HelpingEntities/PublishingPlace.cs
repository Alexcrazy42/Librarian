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

public static class PublishingPlaceHelper
{
    public static IReadOnlyCollection<PublishingPlace> GetPublishingPlaces()
    {
        return new List<PublishingPlace>()
        {
            new PublishingPlace(Guid.Parse("a654195a-7289-4671-8442-027e2f3e74e0"), "Москва"),
            new PublishingPlace(Guid.Parse("c2ebd291-fb56-4068-9be7-965481c737fd"), "Краснодар")
        };
    }
}
