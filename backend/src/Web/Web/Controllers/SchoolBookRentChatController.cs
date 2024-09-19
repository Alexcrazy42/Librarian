using AutoMapper;
using Domain.Contracts.Requests.SchoolRentsRequests;
using Domain.Contracts.Responses.SchoolRentRequests;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("school-rent-chats")]
public class SchoolBookRentChatController : ControllerBase
{
    private readonly ISchoolBookRentService schoolBookRentService;
    private readonly ISchoolBookRentMessageRepository schoolBookRentMessageRepository;
    private readonly ISchoolBookRentMessageService schoolBookRentMessageService;
    private readonly IMapper mapper;

    public SchoolBookRentChatController(ISchoolBookRentService schoolBookRentService,
        IMapper mapper,
        ISchoolBookRentMessageRepository schoolBookRentMessageRepository,
        ISchoolBookRentMessageService schoolBookRentMessageService)
    {
        this.schoolBookRentService = schoolBookRentService;
        this.mapper = mapper;
        this.schoolBookRentMessageRepository = schoolBookRentMessageRepository;
        this.schoolBookRentMessageService = schoolBookRentMessageService;
    }

    [HttpGet("{requestId}")]
    public async Task<IReadOnlyCollection<SchoolRentRequestMessageResponse>> GetLastMessagesFromRequestChatAsync([FromRoute] Guid requestId, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    [HttpGet("can-send")]
    public async Task<bool> CanSendMessageToChatAsync([FromRoute] Guid requestId, [FromRoute] Guid senderId, CancellationToken ct)
    {
        return await schoolBookRentMessageService.CanSendMessageToChatAsync(requestId, senderId, ct);
    }

    [HttpPost("message-to-debtor-request")]
    public async Task<EducationalBookSchoolRentRequestConversationMessageResponse> SendMessageToRequestAsync(SendMessageToRentRequestRequest request, CancellationToken ct)
    {
        var message = await schoolBookRentService.SendMessageToDebtorRequestAsync(request, ct);

        return new EducationalBookSchoolRentRequestConversationMessageResponse()
        {
            Id = message.Id,
            GroundSenderId = message.MessageSender.Id,
            Message = message.Message,
            Status = message.Status,
            RentRequest = mapper.Map<EducationalBookSchoolRentRequestResponse>(message.RentRequest)
        };
    }

    [HttpPost("message-to-owner-response")]
    public async Task<EducationalBookSchoolRentRequestConversationMessageResponse> SendMessageToResponseAsync(SendMessageToRentRequestResponseRequest request, CancellationToken ct)
    {
        var message = await schoolBookRentService.SendMessageToOwnerResponseAsync(request, ct);

        return new EducationalBookSchoolRentRequestConversationMessageResponse()
        {
            Id = message.Id,
            GroundSenderId = message.MessageSender.Id,
            Message = message.Message,
            Status = message.Status,
            RentRequest = mapper.Map<EducationalBookSchoolRentRequestResponse>(message.RentRequest)
        };
    }

    [HttpPut("viewed-messages")]
    public async Task VisibleMessagesAsync([FromBody] IReadOnlyCollection<Guid> messageIds, CancellationToken ct)
    {
        await schoolBookRentMessageRepository.VisibleMessagesAsync(messageIds, ct);
    }
}