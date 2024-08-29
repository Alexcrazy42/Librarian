using Domain.Enums;
using Domain.HelpingEntities;

namespace Domain.Entities.Books;

public class BaseEducationalBook
{
    public static int TitleMaxLength = 200;

    public Guid Id { get; private set; }

    public BookAuthor Author { get; private set; }

    public Editor Editor { get; private set; }

    public string Title { get; private set; }

    public PublishingPlace PublishingPlace { get; private set; }

    public PublishingHouse PublishingHouse { get; private set; }

    public int PublishingSeries { get; private set; }

    public Language Language { get; private set; }

    public Level Level { get; private set; }

    public Appointment Appointment { get; private set; }

    public Subject Subject { get; private set; }

    public int StartClass { get; private set; }

    public int EndClass { get; private set; }

    public DateOnly LeaveFromFederalBooksListAt { get; private set; }

    public IReadOnlyCollection<BookAuthor> AnotherAuthors { get; private set; } = new List<BookAuthor>();

    private BaseEducationalBook() { }

    public BaseEducationalBook(Guid id,
        BookAuthor author,
        Editor editor,
        string title,
        PublishingPlace publishingPlace,
        PublishingHouse publishingHouse,
        int publishingSeries,
        Language language,
        Level level,
        Appointment appointment,
        Subject subject,
        int startClass,
        int endClass,
        IReadOnlyCollection<BookAuthor> anotherAuthors,
        DateOnly leaveFromFederalBooksListAt)
    {
        Id = id;
        Author = author;
        Editor = editor;
        Title = title;
        PublishingPlace = publishingPlace;
        PublishingHouse = publishingHouse;
        PublishingSeries = publishingSeries;
        Language = language;
        Level = level;
        Appointment = appointment;
        Subject = subject;
        StartClass = startClass;
        EndClass = endClass;
        AnotherAuthors = anotherAuthors;
        LeaveFromFederalBooksListAt = leaveFromFederalBooksListAt;
    }
}
