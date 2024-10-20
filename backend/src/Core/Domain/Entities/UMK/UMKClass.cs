using Domain.Entities.SchoolStructure;

namespace Domain.Entities.UMK;

public class UMKClass
{
    public Guid Id { get; private set; }

    public SchoolClass SchoolClass { get; private set; }

    public int StudentCount { get; set; }

    public int? AdjustmentStudentCount { get; set; }

    public float Fullness { get; set; }

    public int NeedCount { get; set; }

    public IReadOnlyCollection<ClassSubject> ClassSubjects { get; set; } = new List<ClassSubject>();

    private UMKClass() { }

    public UMKClass(Guid id)
    {
        Id = id;
    }

    public UMKClass(Guid id, 
        SchoolClass schoolClass, 
        int studentCount)
    {
        Id = id;
        SchoolClass = schoolClass;
        StudentCount = studentCount;
    }
}
