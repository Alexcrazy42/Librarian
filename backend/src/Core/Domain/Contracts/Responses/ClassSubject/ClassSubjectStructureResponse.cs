using Domain.Contracts.Responses.EdBooks;

namespace Domain.Contracts.Responses.ClassSubject;

public class ClassSubjectDto
{
    public Guid SchoolClassId { get; set; }

    public int Number { get; set; }

    public string Name { get; set; }

    public IReadOnlyCollection<ClassSubjectResponse> Subjects { get; set; } = new List<ClassSubjectResponse>();
}

public class ClassSubjectResponse
{
    public Guid Id { get; set; }

    public Guid SubjectId { get; set; }

    public string Name { get; set; }

    public IReadOnlyCollection<ClassSubjectChapterWithBookDto> Chapters { get; set; } = new List<ClassSubjectChapterWithBookDto>();
}

public class ClassSubjectChapterWithBookDto
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public EdBookInBalanceResponse? EdBook { get; set; }
}