namespace Domain.Entities;

public sealed class School
{
    public Guid Id { get; set; }

    public string ShortName { get; private set; }

    public string OfficialName { get; private set; }

    public IReadOnlyCollection<Librarian> Librarians { get; private set; } = new List<Librarian>();

    public IReadOnlyCollection<Employee> Employees { get; private set; } = new List<Employee>();

    public IReadOnlyCollection<SchoolClass> Classes { get; private set; } = new List<SchoolClass>();

    public IReadOnlyCollection<Student> Students { get; private set; } = new List<Student>();

    public IReadOnlyCollection<ImaginativeBook> ImaginativeBooks { get; private set; } = new List<ImaginativeBook>();

    public IReadOnlyCollection<EducationalBook> EducationalBooks { get; private set; } = new List<EducationalBook>();

    private School() { }

    public School(Guid id,
        string shortName,
        string officialName,
        IReadOnlyCollection<Librarian> librarians,
        IReadOnlyCollection<SchoolClass> classes)
    {
        Id = id;
        ShortName = shortName;
        OfficialName = officialName;
        Librarians = librarians;
        Classes = classes;
    }

}
