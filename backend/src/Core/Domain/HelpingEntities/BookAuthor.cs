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

public static class BookAuthorHelper
{
    public static IReadOnlyCollection<BookAuthor> GetBookAuthors()
    {
        return new List<BookAuthor>()
        {
            new BookAuthor(Guid.Parse("2b0489f0-33db-4085-b45c-d93bd1517ff1"), "Пушкин А.С."),
            new BookAuthor(Guid.Parse("01715fbe-af4f-4f19-82d1-7e22201fbd26"), "Достоевский Ф.М.")
        };
    }
}