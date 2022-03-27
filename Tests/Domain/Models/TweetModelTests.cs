using Moq;
using Xunit;
using Domain.Entities;
using Domain.Models;
using System.Net.WebSockets;

using Tests.Fixtures;

public sealed class TweetModelTests : BaseTestFixture
{

    const string AUTHOR = "author";

    const string MESSAGE = "message";

    private Mock<WebSocket> _webSocket;

    public TweetModelTests()
    {
        _webSocket = new();
    }

    [Fact]
    public void ShouldConstructService()
    {
        // Given
        // When
        var result = new TweetModel(_webSocket.Object);
        // Then
        Assert.NotNull(result);
    }

    [Fact]
    public void ShouldSendTweetToSocketWithCancellationToken()
    {
        // Given
        _webSocket.Setup(o => o.SendAsync(
            It.IsAny<ArraySegment<byte>>(),
            WebSocketMessageType.Text,
            true,
            It.IsAny<CancellationToken>()
        )).Returns(new Task(() => Console.WriteLine()));
        var model = new TweetModel(_webSocket.Object);
        var socketTweet = new SocketTweet(AUTHOR, MESSAGE, null);
        // When
        model.SendTweetToSocket(socketTweet, default(CancellationToken));
        // Then
        _webSocket.Verify(o => o.SendAsync(
            It.IsAny<ArraySegment<byte>>(),
            WebSocketMessageType.Text,
            true,
            It.IsAny<CancellationToken>()
        ), Times.Exactly(1));
    }

    [Fact]
    public void ShouldSendTweetToSocketWithoutCancellationToken()
    {
        // Given
        _webSocket.Setup(o => o.SendAsync(
            It.IsAny<ArraySegment<byte>>(),
            WebSocketMessageType.Text,
            true,
            It.IsAny<CancellationToken>()
        )).Returns(new Task(() => Console.WriteLine()));
        var model = new TweetModel(_webSocket.Object);
        var socketTweet = new SocketTweet(AUTHOR, MESSAGE, null);
        // When
        model.SendTweetToSocket(socketTweet);
        // Then
        _webSocket.Verify(o => o.SendAsync(
            It.IsAny<ArraySegment<byte>>(),
            WebSocketMessageType.Text,
            true,
            It.IsAny<CancellationToken>()
        ), Times.Exactly(1));
    }

    [Fact]
    public void ShouldSendTweetToSocketWithoutCancellationTokenNative()
    {
        // Given
        _webSocket.Setup(o => o.SendAsync(
            It.IsAny<ArraySegment<byte>>(),
            WebSocketMessageType.Text,
            true,
            It.IsAny<CancellationToken>()
        )).Returns(new Task(() => Console.WriteLine()));
        var model = new TweetModel(_webSocket.Object);
        var socketTweet = new SocketTweet(AUTHOR, MESSAGE, null);
        // When
        model.SendTweetToSocket(socketTweet);
        // Then
        _webSocket.Verify(o => o.SendAsync(
            It.IsAny<ArraySegment<byte>>(),
            WebSocketMessageType.Text,
            true,
            It.IsAny<CancellationToken>()
        ), Times.Exactly(1));
    }
}
