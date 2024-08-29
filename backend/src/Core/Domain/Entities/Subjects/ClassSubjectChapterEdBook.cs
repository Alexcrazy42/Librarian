using Domain.Entities.Books;

namespace Domain.Entities.Subjects;

public class ClassSubjectChapterEdBook
{
    public Guid Id { get; private set; }

    public ClassSubjectChapter SubjectChapter { get; private set; }

    public BaseEducationalBook? BaseEdBook { get; private set; }

    public EducationalBookInBalance? EdBookInBalance { get; private set; }

    private ClassSubjectChapterEdBook() { }

    public ClassSubjectChapterEdBook(Guid id, 
        ClassSubjectChapter subjectChapter, 
        BaseEducationalBook baseEdBook)
    {
        Id = id;
        SubjectChapter = subjectChapter;
        BaseEdBook = baseEdBook;
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
