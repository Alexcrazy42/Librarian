namespace Domain.Entities;

public sealed class School
{
    public string ShortName { get; private set; }

    public string OfficialName { get; private set; }

    public Librarian Librarian { get; private set; }

    public IReadOnlyCollection<SchoolEmployee> Employees { get; private set; } = new List<SchoolEmployee>();

    public IReadOnlyCollection<SchoolClass> Classes { get; private set; } = new List<SchoolClass>();

    public IReadOnlyCollection<Student> Students { get; private set; } = new List<Student>();

    public IReadOnlyCollection<ImaginativeBook> ImaginativeBooks { get; private set; } = new List<ImaginativeBook>();

    public IReadOnlyCollection<EducationalBook> EducationalBooks { get; private set; } = new List<EducationalBook>();

    public School(string shortName,
        string officialName,
        Librarian librarian,
        IReadOnlyCollection<SchoolClass> classes)
    {
        ShortName = shortName;
        OfficialName = officialName;
        Librarian = librarian;
        Classes = classes;
    }

}
