using Domain.Entities.Books;

namespace Domain.Entities.SchoolStructure;

public sealed class School
{
    public Guid Id { get; private set; }

    public string ShortName { get; private set; }

    public string OfficialName { get; private set; }

    public IReadOnlyCollection<SchoolGround> Grounds { get; set; } = new List<SchoolGround>();

    public IReadOnlyCollection<Librarian> Librarians { get; set; } = new List<Librarian>();

    public IReadOnlyCollection<SchoolClass> Classes { get; set; } = new List<SchoolClass>();

    public IReadOnlyCollection<Employee> Employees { get; private set; } = new List<Employee>();

    public IReadOnlyCollection<Student> Students { get; private set; } = new List<Student>();
    
    public IReadOnlyCollection<EducationalBookInBalance> EducationalBooks { get; private set; } = new List<EducationalBookInBalance>();

    private School() { }

    public School(Guid id,
        string shortName,
        string officialName)
    {
        Id = id;
        ShortName = shortName;
        OfficialName = officialName;
    }

}
