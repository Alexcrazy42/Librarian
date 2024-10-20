namespace Domain.Entities.UMK;

public class ClassSubjectChapter
{
    public const int TitleMaxLength = 100;

    public Guid Id { get; private set; }

    public string Title { get; set; }

    public ClassSubject ClassSubject { get; private set; }

    public int? AdjustmentCount { get; set; }

    public float Fullness { get; set; }

    public int NeedCount { get; set; }

    public int TotalBookCount { get; set; }

    public IReadOnlyCollection<ClassSubjectChapterEdBook> EdBooks { get; private set; } = new List<ClassSubjectChapterEdBook>();

    private ClassSubjectChapter() { }

    public ClassSubjectChapter(Guid id)
    {
        Id = id;
    }

    public ClassSubjectChapter(Guid id, 
        string title)
    {
        Id = id;
        Title = title;
    }
}
