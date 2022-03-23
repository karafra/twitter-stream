using Microsoft.AspNetCore.Mvc;
using Application.Contracts;
using Application.Services;

namespace Presentation.Controllers;

[Controller]
[Route("api")]
public sealed class WebSocketController : Controller
{

  private readonly ILogger _logger;

  private readonly IWebSocketService _webSocketService;

  public WebSocketController(
    ILogger<WebSocketController> logger,
    IWebSocketService webSocketService
  )
  {
    _logger = logger;
    _webSocketService = webSocketService;
  }


  [HttpGet]
  [Route("/ws")]
  public async Task GetWebSocket()
  {
    if (HttpContext.WebSockets.IsWebSocketRequest)
    {
    _logger.LogDebug("Initiating websocket connection");
      using (var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync())
      {
        _logger.LogDebug("Websocket connection established");
        await _webSocketService.Echo(webSocket, default);
      }
    }

  } 
}