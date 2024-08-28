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
