using Domain.Entities.SchoolStructure;
using Domain.HelpingEntities;

namespace Domain.Entities.Subjects;

public class ClassSubject
{
    public Guid Id { get; private set; }
    
    public SchoolClass SchoolClass { get; private set; }

    public Subject Subject { get; private set; }

    public IReadOnlyCollection<ClassSubjectChapter> Chapters { get; private set; } = new List<ClassSubjectChapter>();

    public void SetSubject(Subject subject)
    {
        Subject = subject;
    }

    private ClassSubject() { }

    public ClassSubject(Guid id)
    {
        Id = id;
    }

    public ClassSubject(
        Guid id,
        SchoolClass schoolClass,
        Subject subject,
        IReadOnlyCollection<ClassSubjectChapter> chapters)
    {
        Id = id;
        SchoolClass = schoolClass;
        Subject = subject;
        Chapters = chapters;
    }
}