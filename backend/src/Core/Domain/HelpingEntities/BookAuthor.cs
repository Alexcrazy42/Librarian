using Domain.Entities.Books;

namespace Domain.HelpingEntities;

public class BookAuthor
{
    public static int BookAuthorFullNameMaxLength = 200;

    public Guid Id { get; private set; }

    public string FullName { get; private set; }

    public IReadOnlyCollection<BaseEducationalBook> Books { get; private set; } = new List<BaseEducationalBook>();

    public IReadOnlyCollection<BaseEducationalBook> NonPrimaryBooks { get; private set; } = new List<BaseEducationalBook>();

    private BookAuthor()
    { }

    public BookAuthor(Guid id, string fullName)
    {
        Id = id;
        FullName = fullName;
    }
}
