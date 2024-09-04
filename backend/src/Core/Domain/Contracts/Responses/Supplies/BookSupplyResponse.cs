using Domain.Contracts.Responses.EdBooks;
using System.Dynamic;

namespace Domain.Contracts.Responses.Supplies;

public class BookSupplyResponse
{
    public Guid Id { get; set; }

    public DateOnly SupplyDate { get;  set; }

    public string Supplier { get; set; }

    public string InvoiceNumber { get; set; }

    public bool FullFilled { get; set; }

    public IReadOnlyCollection<EdBookInBalanceResponse> EdBooks { get; set; } = new List<EdBookInBalanceResponse>();
}
