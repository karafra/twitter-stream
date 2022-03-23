using System.Net.WebSockets;


namespace Application.Contracts;

public interface IWebSocketService
{
  public Task Echo(WebSocket socket, CancellationToken cancellationToken = default);

  public Task StreamTweets(WebSocket socket, CancellationToken cancellationToken = default);
}
