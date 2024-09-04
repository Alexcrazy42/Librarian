using Domain.Common;

namespace Domain.Contracts.Responses.Students;

public class StudentDto : Person
{
    public Guid Id { get; set; }

    public bool IsArchived { get; set; }

    public Guid? ClassId { get; set; }
}
