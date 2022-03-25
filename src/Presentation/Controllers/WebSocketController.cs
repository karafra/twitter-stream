using Microsoft.AspNetCore.Mvc;
using Application.Contracts;

namespace Presentation.Controllers;

/// <summary>
/// Controller handling websockets
/// </summary>
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

  /// <summary>
  /// Endpoint to test websocket reception
  /// </summary>
  /// <returns></returns>
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

  /// <summary>
  /// Endpoint that starts socket for streaming of tweets
  /// </summary>
  /// <param name="cancellationToken">Cancellation token</param>
  /// <returns></returns>
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
