namespace Domain.Entities.Subjects;

public class ClassSubjectChapter
{
    public const int TitleMaxLength = 100;

    public Guid Id { get; private set; }

    public string Title { get; private set; }

    public ClassSubject ClassSubject { get; private set; }

    public IReadOnlyCollection<ClassSubjectChapterEdBook> EdBooks { get; private set; } = new List<ClassSubjectChapterEdBook>();

    private ClassSubjectChapter() { }

    public ClassSubjectChapter(Guid id, 
        string title)
    {
        Id = id;
        Title = title;
    }
}
