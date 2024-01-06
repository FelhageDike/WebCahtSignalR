

using Microsoft.AspNetCore.Mvc;

namespace WebChatSignalR.Pl.API.Controllers;

[Controller]
[ApiController]
[Route("Message")]
public class MessageController : ControllerBase
{

    [HttpPost]
    [Route("AddMessage")]
    public async Task<IActionResult> AddMessage()
    {
        return Ok();
    }
}