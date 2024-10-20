using Domain.HelpingEntities;

namespace Domain.Entities.UMK;

public class ClassSubject
{
    public Guid Id { get; private set; }
    
    public UMKClass Class { get; private set; }

    public Subject Subject { get; private set; }

    public float Fullness { get; set; }

    public int NeedCount { get; set; }

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
        UMKClass umkClass,
        Subject subject,
        IReadOnlyCollection<ClassSubjectChapter> chapters)
    {
        Id = id;
        Class = umkClass;
        Subject = subject;
        Chapters = chapters;
    }
}