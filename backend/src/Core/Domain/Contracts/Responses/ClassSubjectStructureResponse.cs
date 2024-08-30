namespace Domain.Contracts.Responses;

public class ClassSubjectStructureResponse
{
    public IReadOnlyCollection<ClassSubject> ClassSubjects { get; set; } = new List<ClassSubject>();
}

public class ClassSubject
{
    public Guid SchoolClassId { get; set; }

    public int Number { get; set; }

    public string Name { get; set; }

    public IReadOnlyCollection<SubjectResponse> Subjects { get; set; } = new List<SubjectResponse>();
}

public class SubjectResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; }
}