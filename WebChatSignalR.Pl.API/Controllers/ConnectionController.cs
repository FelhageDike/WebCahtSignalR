

using Microsoft.AspNetCore.Mvc;

namespace WebChatSignalR.Pl.API.Controllers;

[Controller]
[ApiController]
[Route("Connection")]
public class ConnectionController : ControllerBase
{

    [HttpPost]
    [Route("AddConnection")]
    public async Task<IActionResult> AddConnection()
    {
        return Ok();
    }
    
}