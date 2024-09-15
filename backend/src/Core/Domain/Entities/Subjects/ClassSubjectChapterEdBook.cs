using Domain.Entities.Books;

namespace Domain.Entities.Subjects;

public class ClassSubjectChapterEdBook
{
    public Guid Id { get; private set; }

    public ClassSubjectChapter SubjectChapter { get; private set; }

    public EducationalBookInBalance EdBookInBalance { get; private set; }

    public void SetEdBookInBalance(EducationalBookInBalance edBookInBalance)
    {
        EdBookInBalance = edBookInBalance;
    }

    private ClassSubjectChapterEdBook() { }

    public ClassSubjectChapterEdBook(Guid id)
    {
        Id = id;
    }

    public ClassSubjectChapterEdBook(Guid id,
        ClassSubjectChapter subjectChapter,
        EducationalBookInBalance edBookInBalance)
    {
        Id = id;
        SubjectChapter = subjectChapter;
        EdBookInBalance = edBookInBalance;
    }
}