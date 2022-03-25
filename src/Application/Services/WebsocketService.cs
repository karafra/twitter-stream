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
        while (!result.CloseStatus.HasValue)
        {
            var serverMsg = Encoding.UTF8.GetBytes($"Server: Hello. You said: {Encoding.UTF8.GetString(buffer)}");
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

    private async Task SendTweetsLoop(WebSocket socket, CancellationToken cancellationToken = default)
    {
        var buffer = new Byte[1024 * 4];
        await _twitterClient.NextTweetStreamAsync(
          tweet =>
          {
              var serverMsg = Encoding.UTF8.GetBytes(tweet.Text);
              var segment = new ArraySegment<byte>(serverMsg, 0, serverMsg.Length);
              _logger.LogInformation($"Tweet {tweet.Text} sent to socket");
              socket.SendAsync(segment, WebSocketMessageType.Text, true, cancellationToken);
          }
        );
    }

    public async Task StreamTweets(WebSocket socket, CancellationToken cancellationToken = default)
    {
        CancellationTokenSource taskController = new CancellationTokenSource();
        CancellationToken token;
        if (cancellationToken == default(CancellationToken))
        {
            token = taskController.Token;
        }
        else
        {
            token = cancellationToken;
        }

        var buffer = new Byte[1024 * 4];
        Task task = Task.Run(async () => await SendTweetsLoop(socket, token), token);

        WebSocketReceiveResult result;
        do
        {
            result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), token);
        } while (!result.CloseStatus.HasValue);
        if (!cancellationToken.IsCancellationRequested)
        {
            _twitterClient.CancelTweetStream();
            taskController.Cancel();
        }
    }
}
