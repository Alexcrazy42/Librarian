namespace Domain.Contracts.Requests.Students;

public class TransferStudentsFromOneClassToAnotherRequest
{
    public Guid OldClass { get; set; }

    public Guid NewClass { get; set; }
}
