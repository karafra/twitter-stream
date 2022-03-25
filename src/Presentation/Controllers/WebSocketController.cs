using Microsoft.AspNetCore.Mvc;
using Application.Contracts;

namespace Presentation.Controllers;

[Route("ws")]
[ApiController]
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
  [Route("/echo")]
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

  [HttpGet]
  [Route("/tweetStream")]
  public async Task StreamTweets(CancellationToken cancellationToken = default)
  {
    using (var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync())
    {
      await _webSocketService.StreamTweets(webSocket, cancellationToken);
    }
  } 
}
