namespace Domain.Entities;

public sealed class SchoolClass
{
    public Guid Id { get; set; }

    public int Number { get; set; }

    public string Name { get; set; }

    public School School { get; set; }

    public Employee Manager { get; set; }

    public IReadOnlyCollection<Student> Students { get; set; } = new List<Student>();

    private SchoolClass()
    { }

    public SchoolClass(Guid id,
        string name,
        School school,
        Employee manager)
    {
        Id = id;
        Name = name;
        School = school;
        Manager = manager;
    }
}
