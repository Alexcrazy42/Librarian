using Domain.Entities.Books;

namespace Domain.HelpingEntities;

public class Subject
{
    public static int NameMaxLength = 200;

    public Guid Id { get; private set; }
    
    public string Name { get; private set; }

    public IReadOnlyCollection<BaseEducationalBook> Books { get; private set; } = new List<BaseEducationalBook>();

    private Subject() 
    { }

    public Subject(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}

public static class SubjectHelper
{
    public static IReadOnlyCollection<Subject> GetSubjects()
    {
        return new List<Subject>()
        {
            new Subject(Guid.Parse("0e07794f-baf8-48aa-9982-7d0c710ec817"), "Математика"),
            new Subject(Guid.Parse("d421fbe4-3638-4e33-ae93-31e77e063a0f"), "Русский язык")
        };
    }
}

