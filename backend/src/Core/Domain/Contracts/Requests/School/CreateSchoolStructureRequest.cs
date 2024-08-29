namespace Domain.Contracts.Requests.School;

public class CreateSchoolStructureRequest
{
    public string ShortName { get; set; }

    public string OfficialName { get; set; }

    public IReadOnlyCollection<CreateSchoolGroundRequest> Grounds { get; set; } = new List<CreateSchoolGroundRequest>();
}

public class CreateSchoolGroundRequest
{
    public string Name { get; set; }

    public IReadOnlyCollection<CreateSchoolClassRequest> Classes { get; set; } = new List<CreateSchoolClassRequest>();

    public IReadOnlyCollection<CreateLibrarianRequest> Librarians { get; set; } = new List<CreateLibrarianRequest>();
}

public class CreateSchoolClassRequest
{
    public int Number { get; set; }

    public string Name { get; set; }

    public int SubjectCount { get; set; }
}

public class CreateLibrarianRequest
{
    public string Surname { get; set; }

    public string Name { get; set; }

    public string Patronymic { get; set; }

    public bool IsGeneral { get; set; }
}