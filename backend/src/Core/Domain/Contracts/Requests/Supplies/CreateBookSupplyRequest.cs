namespace Domain.Contracts.Requests.Supplies;

public class CreateBookSupplyRequest
{
    public DateOnly SupplyDate { get; set; }

    public string Supplier { get; set; }

    public string InvoiceNumber { get; set; }

    public Guid GroundId { get; set; }
}
