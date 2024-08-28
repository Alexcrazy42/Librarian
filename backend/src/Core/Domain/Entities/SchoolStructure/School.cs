using Domain.Entities.Books;

namespace Domain.Entities.SchoolStructure;

public sealed class School
{
    public Guid Id { get; private set; }

    public string ShortName { get; private set; }

    public string OfficialName { get; private set; }

    public IReadOnlyCollection<Librarian> Librarians { get; private set; } = new List<Librarian>();

    public IReadOnlyCollection<SchoolPlayground> Playgrounds { get; private set; } = new List<SchoolPlayground>(); 

    public IReadOnlyCollection<Employee> Employees { get; private set; } = new List<Employee>();

    public IReadOnlyCollection<SchoolClass> Classes { get; private set; } = new List<SchoolClass>();

    public IReadOnlyCollection<Student> Students { get; private set; } = new List<Student>();
    
    public IReadOnlyCollection<EducationalBookInBalance> EducationalBooks { get; private set; } = new List<EducationalBookInBalance>();

    private School() { }

    public School(Guid id,
        string shortName,
        string officialName,
        IReadOnlyCollection<Librarian> librarians,
        IReadOnlyCollection<SchoolPlayground> playgrounds,
        IReadOnlyCollection<SchoolClass> classes)
    {
        Id = id;
        ShortName = shortName;
        OfficialName = officialName;
        Librarians = librarians;
        Playgrounds = playgrounds;
        Classes = classes;
    }

}
