using System.Text;
using System.Net.WebSockets;
using Domain.Entities;
using TwitterSharp.Response.RTweet;

namespace Domain.Models;

/// <summary>
/// Model for sendign tweets to socket.
/// </summary>
public sealed class TweetModel
{

    /// <summary>
    /// Socket to send tweets to.
    /// </summary>
    private readonly WebSocket _socket;

    /// <summary>
    /// Constructs model from websocket.
    /// </summary>
    /// <param name="socket">Socket to which tweets will be sent</param>
    public TweetModel(WebSocket socket)
    {
        _socket = socket;
    }

    /// <summary>
    /// Sends tweet to socket.
    /// </summary>
    /// <param name="socketTweet">Tweet to send</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    public Task SendTweetToSocket(
        SocketTweet socketTweet,
        CancellationToken cancellationToken
    )
    {
        var serverMsg =
            Encoding.UTF8.GetBytes(socketTweet.ToString());
        var segment =
            new ArraySegment<byte>(serverMsg, 0, serverMsg.Length);
        return 
            _socket.SendAsync(
                segment,
                WebSocketMessageType.Text,
                true,
                cancellationToken
            );
    }

    /// <summary>
    /// Sends tweet to socket without cancelllion token.
    /// </summary>
    /// <param name="socketTweet">Tweet to send</param>
    /// <returns></returns>
    public Task SendTweetToSocket(SocketTweet socketTweet)
    {
        return SendTweetToSocket(
            socketTweet,
            default
        );
    }

    /// <summary>
    /// Sends tweet to socket without cancellation token.
    /// </summary>
    /// <param name="tweet">Tweet to sent</param>
    /// <returns></returns>
    public Task SendTweetToSocket(Tweet tweet)
    {
        return SendTweetToSocket(
            new SocketTweet(tweet),
            default
        );
    }

    /// <summary>
    /// Sends tweet to socket
    /// </summary>
    /// <param name="tweet">Tweet to send</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    public Task SendTweetToSocket(
        Tweet tweet,
        CancellationToken cancellationToken
    )
    {
        return SendTweetToSocket(
            new SocketTweet(tweet),
            cancellationToken
        );
    }
}
