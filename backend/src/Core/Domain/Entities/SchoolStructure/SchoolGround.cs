using Domain.Entities.Books;

namespace Domain.Entities.SchoolStructure;

public class SchoolGround
{
    private string _name;

    public Guid Id { get; private set; }

    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }

    public School School { get; set; }

    public IReadOnlyCollection<SchoolClass> Classes { get; set; } = new List<SchoolClass>();

    public IReadOnlyCollection<Librarian> Librarians { get; set; } = new List<Librarian>();

    public IReadOnlyCollection<Employee> Employees { get; private set; } = new List<Employee>();

    public IReadOnlyCollection<Student> Students { get; private set; } = new List<Student>();

    public IReadOnlyCollection<EducationalBookInBalance> EducationalBooks { get; private set; } = new List<EducationalBookInBalance>();

    private SchoolGround() { }

    public SchoolGround(Guid id)
    {
        Id = id;
    }

    public SchoolGround(Guid id, string name, School school)
    {
        Id = id;
        Name = name;
        School = school;
    }
}
