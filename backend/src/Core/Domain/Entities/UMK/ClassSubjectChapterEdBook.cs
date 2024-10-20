using Domain.Entities.Books;

namespace Domain.Entities.UMK;

public class ClassSubjectChapterEdBook
{
    public Guid Id { get; private set; }

    public ClassSubjectChapter SubjectChapter { get; private set; }


    public IReadOnlyCollection<EducationalBookInBalance> EdBooksInBalance = new List<EducationalBookInBalance>();

    public void SetEdBooksInBalance(IReadOnlyCollection<EducationalBookInBalance> edBooksInBalance)
    {
        EdBooksInBalance = edBooksInBalance;
    }

    private ClassSubjectChapterEdBook() { }

    public ClassSubjectChapterEdBook(Guid id)
    {
        Id = id;
    }

    public ClassSubjectChapterEdBook(Guid id,
        ClassSubjectChapter subjectChapter,
        IReadOnlyCollection<EducationalBookInBalance> edBooksInBalance)
    {
        Id = id;
        SubjectChapter = subjectChapter;
        EdBooksInBalance = edBooksInBalance;
    }
}