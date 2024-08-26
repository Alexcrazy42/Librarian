namespace Domain.HelpingEntities;

public class BookAuthor
{
    public Guid Id { get; set; }

    public string FullName { get; set; }

    private BookAuthor()
    { }

    public BookAuthor(Guid id, string fullName)
    {
        Id = id;
        FullName = fullName;
    }
}
