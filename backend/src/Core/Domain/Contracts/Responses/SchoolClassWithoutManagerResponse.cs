namespace Domain.Contracts.Responses;

public class SchoolClassWithoutManagerResponse
{
    public Guid Id { get; private set; }

    public int Number { get; private set; }

    public string Name { get; private set; }

    public int SubjectCount { get; private set; }

    public Guid GroundId { get; private set; }

    public Guid SchoolId { get; private set; }

    public SchoolClassWithoutManagerResponse(Guid id, 
        int number, 
        string name, 
        int subjectCount, 
        Guid groundId, 
        Guid schoolId)
    {
        Id = id;
        Number = number;
        Name = name;
        SubjectCount = subjectCount;
        GroundId = groundId;
        SchoolId = schoolId;
    }
}
