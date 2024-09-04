using Domain.Entities.Books;

namespace Domain.HelpingEntities;

public class Editor
{
    public static int EditorNameMaxLength = 200;

    public Guid Id { get; private set; }

    public string FullName { get; private set; }

    public IReadOnlyCollection<BaseEducationalBook> Books { get; private set; } = new List<BaseEducationalBook>();

    private Editor()
    { }

    public Editor(Guid id, string fullName)
    {
        Id = id;
        FullName = fullName;
    }
}

public static class EditorHelper
{
    public static IReadOnlyCollection<Editor> GetEditors()
    {
        return new List<Editor>()
        {
            new Editor(Guid.Parse("10b8b598-e5a4-4633-bb20-056fa10d3863"), "Пушкин А.С."),
            new Editor(Guid.Parse("1aebd275-e6e3-4697-93e3-963dd25d0050"), "Достоевский Ф.М.")
        };
    }
}
