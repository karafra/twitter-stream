using System.Net.WebSockets;


namespace Application.Contracts;

/// <summary>
/// Interface for WebSocketService
/// </summary>
public interface IWebSocketService
{
  /// <summary>
  /// Method that should verify connection
  /// </summary>
  /// <param name="socket">Senders socket</param>
  /// <param name="cancellationToken">Cancellation token</param>
  /// <returns></returns>
  public Task Echo(WebSocket socket, CancellationToken cancellationToken = default);

  /// <summary>
  /// Should stream tweets to given websocket
  /// </summary>
  /// <param name="socket">Socket opened by user</param>
  /// <param name="cancellationToken">Cancellation token</param>
  /// <returns></returns>
  public Task StreamTweets(WebSocket socket, CancellationToken cancellationToken = default);
}
