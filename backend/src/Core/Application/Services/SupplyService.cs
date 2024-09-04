using Domain.Contracts.Requests.Supplies;
using Domain.Entities.Supplies;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Application.Services;

internal class SupplyService : ISupplyService
{
    public readonly ISupplyRepository supplyRepository;
    private readonly ISchoolRepository schoolRepository;

    public SupplyService(ISupplyRepository supplyRepository,
        ISchoolRepository schoolRepository)
    {
        this.supplyRepository = supplyRepository;
        this.schoolRepository = schoolRepository;
    }

    public async Task<Guid> CreateSupplyAsync(CreateBookSupplyRequest request, CancellationToken ct)
    {
        var (school, ground) = await schoolRepository.GetSchoolAndGroundByGroundId(request.GroundId, ct);

        var supply = new BookSupply(
            id: Guid.NewGuid(),
            ground: ground,
            school: school,
            supplyDate: request.SupplyDate,
            supplier: request.Supplier,
            invoiceNumber: request.InvoiceNumber,
            fullFilled: false
        );

        return await supplyRepository.CreateBookSupplyAndGetIdAsync(supply, ct);
    }
}
