using System.Text;
using Microsoft.Extensions.Logging;
using System.Net.WebSockets;
using Application.Contracts;
using TwitterSharp.Client;
namespace Application.Services;

public sealed class WebSocketService : IWebSocketService
{
  private ILogger _logger;

  private TwitterClient _twitterClient;

  public WebSocketService(
    ILogger<IWebSocketService> logger,
    TwitterClient twitterClient
    )
  {
    _logger = logger;
    _twitterClient = twitterClient;
  }

  public async Task Echo(WebSocket socket, CancellationToken cancellationToken = default)
  {
    var buffer = new Byte[1024 * 4];
    var result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken);
    while(!result.CloseStatus.HasValue)
    {
      var serverMsg =  Encoding.UTF8.GetBytes($"Server: Hello. You said: {Encoding.UTF8.GetString(buffer)}");
      await socket.SendAsync(
        new ArraySegment<byte>(serverMsg, 0, serverMsg.Length),
        result.MessageType,
        result.EndOfMessage,
        cancellationToken);
      _logger.LogInformation("Message sent to client");
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

  public async Task StreamTweets(WebSocket socket, CancellationToken cancellationToken = default)
  {
    await _twitterClient.NextTweetStreamAsync(tweet => {
      var buffer = Encoding.Unicode.GetBytes(tweet.Text);
      var segment = new ArraySegment<byte>(buffer);
      Console.WriteLine(tweet.Text);
      socket.SendAsync(segment, WebSocketMessageType.Text, true, cancellationToken);
    });
  }
}