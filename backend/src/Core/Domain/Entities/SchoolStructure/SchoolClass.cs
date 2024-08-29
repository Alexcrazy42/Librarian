using Domain.Entities.Subjects;

namespace Domain.Entities.SchoolStructure;

public sealed class SchoolClass
{
    public Guid Id { get; private set; }

    public int Number { get; private set; }

    public string Name { get; private set; }

    public int SubjectCount { get; private set; }

    public School School { get; private set; }

    public SchoolGround Ground { get; private set; }

    public Employee Manager { get; private set; }

    public IReadOnlyCollection<Student> Students { get; private set; } = new List<Student>();

    public IReadOnlyCollection<ClassSubject> ClassSubjects { get; private set; } = new List<ClassSubject>();

    private SchoolClass()
    { }

    public SchoolClass(Guid id,
        int number,
        string name,
        int subjectCount,
        School school,
        SchoolGround ground)
    {
        Id = id;
        Number = number;
        Name = name;
        SubjectCount = subjectCount;
        School = school;
        Ground = ground;
    }
}
