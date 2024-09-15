using Domain.Contracts.Responses.SchoolRentRequests;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("school-rent-chats")]
public class SchoolBookRentChatController : ControllerBase
{
    [HttpGet("{requestId}")]
    public async Task<IReadOnlyCollection<SchoolRentRequestMessageResponse>> GetLastMessagesFromRequestChatAsync([FromRoute] Guid requestId, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    [HttpGet("can-send")]
    public async Task CanSendMessageToChatAsync(CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task SendMessageToChatAsync()
    {
        throw new NotImplementedException();
    }
}