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

public static class PublishingHouseHelper
{
    public static IReadOnlyCollection<PublishingHouse> GetPublishingHouses()
    {
        return new List<PublishingHouse>()
        {
            new PublishingHouse(Guid.Parse("e2b4aea0-72eb-4c15-b8df-a2e3a5e7a2ca"), "Издательство"),
            new PublishingHouse(Guid.Parse("4616bbb8-68b7-40b8-ab49-72c7bfae2302"), "Просвещение")
        };
    }
}

