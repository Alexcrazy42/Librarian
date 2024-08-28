using Domain.Entities.Books;

namespace Domain.Entities.SchoolStructure;

public class SchoolPlayground
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public School School { get; private set; }

    public IReadOnlyCollection<SchoolClass> Classes { get; private set; } = new List<SchoolClass>();

    public IReadOnlyCollection<Librarian> Librarians { get; private set; } = new List<Librarian>();

    public IReadOnlyCollection<Employee> Employees { get; private set; } = new List<Employee>();

    public IReadOnlyCollection<Student> Students { get; private set; } = new List<Student>();

    public IReadOnlyCollection<EducationalBookInBalance> EducationalBooks { get; private set; } = new List<EducationalBookInBalance>();
}
