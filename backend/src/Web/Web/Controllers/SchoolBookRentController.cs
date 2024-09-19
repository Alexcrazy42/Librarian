using AutoMapper;
using Domain.Contracts.Requests.SchoolRentsRequests;
using Domain.Contracts.Responses.EdBooks;
using Domain.Contracts.Responses.School;
using Domain.Contracts.Responses.SchoolRentRequests;
using Domain.Entities.RentRequests;
using Domain.Enums;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("api/school-rents")]
public class SchoolBookRentController : ControllerBase
{
    private readonly IEdBookInBalanceRepository edBookInBalanceRepository;
    private readonly ISchoolBookRentService schoolBookRentService;
    private readonly ISchoolBookRentRepository schoolBookRentRepository;
    private readonly IMapper mapper;

    public SchoolBookRentController(IEdBookInBalanceRepository edBookInBalanceRepository,
        ISchoolBookRentService schoolBookRentService,
        ISchoolBookRentRepository schoolBookRentRepository,
        IMapper mapper)
    {
        this.edBookInBalanceRepository = edBookInBalanceRepository;
        this.schoolBookRentService = schoolBookRentService;
        this.schoolBookRentRepository = schoolBookRentRepository;
        this.mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<EducationalBookSchoolRentRequestResponse> GetAsync([FromRoute] Guid id, CancellationToken ct)
    {
        var rentRequest = await schoolBookRentRepository.GetAsync(id, ct);

        return mapper.Map<EducationalBookSchoolRentRequestResponse>(rentRequest);
    }

    [HttpGet("schools-with-needed-book/{baseEdBookId}")]
    public async Task<IReadOnlyCollection<SchoolGroundWithEdBookResponse>> GetSchoolsHaveFamiliarEdBookAsync([FromRoute] Guid baseEdBookId, CancellationToken ct)
    {
        var books = await edBookInBalanceRepository.GetEdBooksInBalanceByBaseEdBookIdAsync(baseEdBookId, ct);

        return mapper.Map<IReadOnlyCollection<SchoolGroundWithEdBookResponse>>(books);
    }

    [HttpGet("all-sended-requests/{groundId}")]
    public async Task<IReadOnlyCollection<EducationalBookSchoolRentRequestResponse>> GetAllSendedRequests([FromRoute] Guid groundId, CancellationToken ct)
    {
        var requests = await schoolBookRentRepository.GetAllSendedRequests(groundId, ct);

        return mapper.Map<IReadOnlyCollection<EducationalBookSchoolRentRequestResponse>>(requests);
    }

    [HttpGet("all-received-requests/{groundId}")]
    public async Task<IReadOnlyCollection<EducationalBookSchoolRentRequestResponse>> GetAllReceivedRequestsAsync([FromRoute] Guid groundId, CancellationToken ct)
    {
        var requests = await schoolBookRentRepository.GetAllReceivedRequestsAsync(groundId, ct);

        return mapper.Map<IReadOnlyCollection<EducationalBookSchoolRentRequestResponse>>(requests);
    }


    [HttpPost]
    public async Task<EducationalBookSchoolRentRequestResponse> CreateSchoolRentRequestAsync([FromBody] CreateSchoolRentRequest request, CancellationToken ct)
    {
        var rentRequest = await schoolBookRentService.CreateSchoolRentAsync(request, ct);

        return mapper.Map<EducationalBookSchoolRentRequestResponse>(rentRequest);
    }


    [HttpPut("close-request-by-debtor/{requestId}")]
    public async Task CloseRequestByDebtorAsync([FromRoute] Guid requestId, CancellationToken ct)
    {
        await schoolBookRentService.CloseRequestByDebtorAsync(requestId, ct);
    }

    [HttpPut("close-by-owner/{requestId}")]
    public async Task CloseRequestByOwnerAsync([FromRoute] Guid requestId, CancellationToken ct)
    {
        await schoolBookRentService.CloseRequestByOwnerAsync(requestId, ct);
    }

    [HttpPut("send-by-owner/{requestId}")]
    public async Task SendBooksByOwnerAsync([FromRoute] Guid requestId, CancellationToken ct)
    {
        await schoolBookRentService.SendBooksByOwnerAsync(requestId, ct);
    }

    [HttpPut("received-by-debtor/{requestId}")]
    public async Task ReceivedBooksByDebtorAsync([FromRoute] Guid requestId, CancellationToken ct)
    {
        await schoolBookRentService.ReceiveBooksByDebtorAsync(requestId, ct);
    }

    [HttpPut("visible-request/{requestId}")]
    public async Task SetVisibleOfRequestAsync([FromRoute] Guid requestId, CancellationToken ct)
    {
        await schoolBookRentService.SetVisibleOfRequestAsync(requestId, ct);
    }

    [HttpPut("visible-response/{requestId}")]
    public async Task SetVisibleOfResponseAsync([FromRoute] Guid requestId, CancellationToken ct)
    {
        await schoolBookRentService.SetVisibleOfResponseAsync(requestId, ct);
    }
}