using Domain.Entities.Books;
using Domain.Entities.SchoolStructure;

namespace Domain.Entities.Supplies;

public class BookSupply
{
    public const int SupplierMaxLength = 200;
    public const int InvoiceNumberMaxLength = 100;

    public Guid Id { get; private set; }

    public SchoolGround Ground { get; private set; }

    public School School { get; private set; }

    public DateOnly SupplyDate { get; private set; }

    public string Supplier { get; private set; }

    public string InvoiceNumber { get; private set; }

    public bool FullFilled { get; private set; }

    public IReadOnlyCollection<EducationalBookInBalance> EdBooks { get; private set; } = new List<EducationalBookInBalance>();

    public void EndFilling()
    {
        FullFilled = true;
    }

    private BookSupply() { }

    public BookSupply(Guid id)
    {
        Id = id;
    }

    public BookSupply(Guid id, 
        SchoolGround ground,
        School school,
        DateOnly supplyDate, 
        string supplier,
        string invoiceNumber, 
        bool fullFilled)
    {
        Id = id;
        Ground = ground;
        School = school;
        SupplyDate = supplyDate;
        Supplier = supplier;
        InvoiceNumber = invoiceNumber;
        FullFilled = fullFilled;
    }
}
