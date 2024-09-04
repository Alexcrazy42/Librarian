namespace Domain.Contracts.Requests.ClassSubjects;

public class CreateClassSubjectStructureRequest
{
    public Guid GroundId { get; set; }

    public IReadOnlyCollection<CreateClassSubject> ClassSubjects { get; set; } = new List<CreateClassSubject>();
}

public class CreateClassSubject
{
    public Guid SchoolClassId { get; set; }

    public IReadOnlyCollection<CreateSubjectRequest> Subjects { get; set; } = new List<CreateSubjectRequest>();
}

public class CreateSubjectRequest
{
    public Guid? SubjectId { get; set; }

    public string? SubjectName { get; set; }

    public IReadOnlyCollection<string> ChapterNames { get; set; } = new List<string>();
}