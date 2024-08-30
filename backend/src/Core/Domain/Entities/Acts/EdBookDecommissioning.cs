using Domain.Entities.Books;
using Domain.Enums;

namespace Domain.Entities.Acts;

public class EdBookDecommissioning
{
    public Guid Id { get; private set; }

    public EdBookDecommissioningReason Reason { get; private set; }

    public DateOnly Date { get; private set; }

    public EducationalBookInBalance EdBook { get; private set; }

    public int Count { get; private set; }

    public bool InspectorApproved { get; private set; }

    public DateOnly ApprovedDate { get; private set; }

    private EdBookDecommissioning() { }

    public EdBookDecommissioning(
        Guid id, 
        EdBookDecommissioningReason reason, 
        DateOnly date, 
        EducationalBookInBalance 
        edBook, 
        int count, 
        bool inspectorApproved, 
        DateOnly approvedDate
    )
    {
        Id = id;
        Reason = reason;
        Date = date;
        EdBook = edBook;
        Count = count;
        InspectorApproved = inspectorApproved;
        ApprovedDate = approvedDate;
    }
}
