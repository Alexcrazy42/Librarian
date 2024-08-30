using Domain.Entities.Books;

namespace Domain.Entities.Supplies;

public class BookSupply
{
    public const int SupplierMaxLength = 200;
    public const int InvoiceNumberMaxLength = 100;

    public Guid Id { get; private set; }

    public DateOnly SupplyDate { get; private set; }

    public string Supplier { get; private set; }

    public string InvoiceNumber { get; private set; }

    public IReadOnlyCollection<EducationalBookInBalance> EdBooks { get; private set; } = new List<EducationalBookInBalance>();

    private BookSupply() { }

    public BookSupply(Guid id, 
        DateOnly supplyDate, 
        string supplier,
        string invoiceNumber, 
        IReadOnlyCollection<EducationalBookInBalance> edBooks)
    {
        Id = id;
        SupplyDate = supplyDate;
        Supplier = supplier;
        InvoiceNumber = invoiceNumber;
        EdBooks = edBooks;
    }
}
