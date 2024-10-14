using Domain.Entities.Books;

namespace Domain.Entities.Subjects;

public class ClassSubjectChapterEdBook
{
    public Guid Id { get; private set; }

    public ClassSubjectChapter SubjectChapter { get; private set; }

    public BaseEducationalBook BaseEducationalBook { get; private set; }

    public void SetEdBookInBalance(BaseEducationalBook baseEducationalBook)
    {
        BaseEducationalBook = baseEducationalBook;
    }

    private ClassSubjectChapterEdBook() { }

    public ClassSubjectChapterEdBook(Guid id)
    {
        Id = id;
    }

    public ClassSubjectChapterEdBook(Guid id,
        ClassSubjectChapter subjectChapter,
        BaseEducationalBook baseEducationalBook)
    {
        Id = id;
        SubjectChapter = subjectChapter;
        BaseEducationalBook = baseEducationalBook;
    }
}