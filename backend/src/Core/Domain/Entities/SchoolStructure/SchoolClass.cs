namespace Domain.Entities.SchoolStructure;

public sealed class SchoolClass
{
    public Guid Id { get; private set; }

    public int Number { get; private set; }

    public string Name { get; private set; }

    public School School { get; private set; }

    public SchoolPlayground Playground { get; private set; }

    public Employee Manager { get; private set; }

    public IReadOnlyCollection<Student> Students { get; private set; } = new List<Student>();

    private SchoolClass()
    { }

    public SchoolClass(Guid id,
        string name,
        School school,
        SchoolPlayground playground,
        Employee manager)
    {
        Id = id;
        Name = name;
        School = school;
        Playground = playground;
        Manager = manager;
    }
}
