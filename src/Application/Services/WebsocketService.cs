using System.Text;
using Microsoft.Extensions.Logging;
using System.Net.WebSockets;
using Application.Contracts;
using TwitterSharp.Client;
using Domain.Models;

namespace Application.Services;

/// <summary>
/// Service handling websockets
/// </summary>
public sealed class WebSocketService : IWebSocketService
{
    private ILogger _logger;

    private TwitterClient _twitterClient;

    /// <summary>
    /// Service handling websockets
    /// </summary>
    /// <param name="logger">logger serbice</param>
    /// <param name="twitterClient">twitter client</param>
    public WebSocketService(
      ILogger<IWebSocketService> logger,
      TwitterClient twitterClient
      )
    {
        _logger = logger;
        _twitterClient = twitterClient;
    }

    /// <summary>
    /// Echoes given message to senders websocket in format "Server: Hello. You said: {Message}"
    /// </summary>
    /// <param name="socket">Socket opened by client</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
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
        var model = new TweetModel(socket);
        await _twitterClient.NextTweetStreamAsync(
          tweet =>
          {
              model.SendTweetToSocket(tweet);
              _logger.LogInformation($"Tweet {tweet.Text} sent to socket");
          }
        );
    }

    /// <summary>
    /// Strems tweets to socket opened by user
    /// </summary>
    /// <param name="socket">Socket opened by user</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
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
