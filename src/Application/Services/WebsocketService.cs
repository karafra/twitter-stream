using System.Text;
using Microsoft.Extensions.Logging;
using System.Net.WebSockets;
using Application.Contracts;

namespace Application.Services;

public sealed class WebSocketService : IWebSocketService
{
  private ILogger _logger;
  public WebSocketService(ILogger<WebSocketService> logger)
  {
    _logger = logger;
  }

  public async Task Echo(WebSocket socket, CancellationToken cancellationToken = default)
  {
    var buffer = new Byte[1024 * 4];
    var result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
    while(!result.CloseStatus.HasValue)
    {
      var serverMsg =  Encoding.UTF8.GetBytes($"Server: Hello. You said: {Encoding.UTF8.GetString(buffer)}");
      await socket.SendAsync(
        new ArraySegment<byte>(serverMsg, 0, serverMsg.Length),
        result.MessageType,
        result.EndOfMessage,
        cancellationToken);
      _logger.LogInformation("Message sent from client");
      result = await socket.ReceiveAsync(
        new ArraySegment<byte>(buffer),
        cancellationToken
      );
      _logger.LogInformation("Message received from client");
    }
    _logger.LogInformation("Closing connection to socket");
    await socket.CloseAsync(
      result.CloseStatus.Value,
      result.CloseStatusDescription,
      cancellationToken
    );
    _logger.LogInformation("Connection closed");
  }
}