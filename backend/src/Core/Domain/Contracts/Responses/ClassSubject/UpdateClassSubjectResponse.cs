using Domain.Contracts.Responses.Subjects;

namespace Domain.Contracts.Responses.ClassSubject;

public class UpdateClassSubjectResponse
{
    public Guid Id { get; set; }

    public SubjectResponse Subject { get; set; }
}
