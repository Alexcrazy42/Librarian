
namespace Domain.Contracts.Responses.Umk;

public class UmkStructureForGroundResponse
{
    public Guid GroundId { get; set; }

    public IReadOnlyCollection<UmkClassResponse> UmkClasses { get; set; } = new List<UmkClassResponse>();
}

public class UmkClassResponse
{
    public Guid Id { get; set; }

    public Guid SchoolClassId { get; set; }

    public int Number { get; set; }
    
    public string Name { get; set; }

    public IReadOnlyCollection<ClassSubjectRespponse> ClassSubjects { get; set; } = new List<ClassSubjectRespponse>();
}

public class ClassSubjectRespponse
{
    public Guid Id { get; set; }

    public string SubjectName { get; set; }

    public IReadOnlyCollection<ClassSubjectChapterResponse> ClassSubjectChapters { get; set; } = new List<ClassSubjectChapterResponse>();
}

public class ClassSubjectChapterResponse
{
    public Guid Id { get; set; }

    public string Title { get; set; }
}