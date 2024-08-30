using System.Dynamic;

namespace Domain.Contracts.Requests.ClassSubjects;

public class CreateClassSubjectStructureRequest
{
    public Guid GroundId { get; set; }

    public IReadOnlyCollection<ClassSubject> ClassSubjects { get; set; } = new List<ClassSubject>();
}

public class ClassSubject
{
    public Guid SchoolClassId { get; set; }

    public IReadOnlyCollection<CreateSubjectRequest> Subjects { get; set; } = new List<CreateSubjectRequest>();
}

public class CreateSubjectRequest
{
    public Guid? SubjectId { get; set; }

    public string? SubjectName { get; set; }
}