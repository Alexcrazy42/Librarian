using Domain.Common;

namespace Domain.Contracts.Requests.Students;

public class AddStudentsToClassRequest
{
    public Guid ClassId { get; set; }

    public IReadOnlyCollection<StudentCreationDto> Students { get; set; } = new List<StudentCreationDto>();
}

public class StudentCreationDto : Person
{
    
}