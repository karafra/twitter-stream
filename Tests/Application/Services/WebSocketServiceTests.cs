using Tests.Fixtures;
using Xunit;
using Moq;
using System.Net.WebSockets;
using Application.Contracts;
using Microsoft.Extensions.Logging;
using Infrastructure.Twitter;
using Application.Services;
using TwitterSharp.Response.RTweet;

namespace Tests.Application.Services;

public sealed class WebSocketServiceTests : BaseTestFixture
{
    private IWebSocketService service;

    private Mock<ILogger<IWebSocketService>> mockSocketLogger;

    private Mock<ILogger<TwitterClient>> mockClientLogger;
    private Mock<TwitterClient> mockTwitterClient;

    private WebSocketReceiveResult closingWebSocketReceiveResult;

    private WebSocketReceiveResult continuingWebSocketReceiveResult;

    private string closingReceiveResultMessage = "closingReceiveResultMessage";

    public WebSocketServiceTests() : base()
    {
        mockSocketLogger = new();
        mockClientLogger = new();
        mockTwitterClient = new(configuration, mockClientLogger.Object);
        service = new WebSocketService(mockSocketLogger.Object, mockTwitterClient.Object);
        closingWebSocketReceiveResult = new WebSocketReceiveResult(
          8,
          WebSocketMessageType.Close,
          true,
          WebSocketCloseStatus.Empty,
          closingReceiveResultMessage
        );
        continuingWebSocketReceiveResult = new WebSocketReceiveResult(
          8,
          WebSocketMessageType.Close,
          true
        );
    }

    [Fact]
    public async void ShouldEchoToSocketAndCloseASAP()
    {
        // Given
        var mockSocket = new Mock<WebSocket>();
        mockSocket.Setup(o => o.ReceiveAsync(
            It.IsAny<ArraySegment<byte>>(),
            It.IsAny<CancellationToken>()
          )
        ).Returns(
          Task.FromResult<WebSocketReceiveResult>(closingWebSocketReceiveResult)
        );
        // When
        await service.Echo(mockSocket.Object);
        // Then
        mockSocket.Verify(o => o.ReceiveAsync(
          It.IsAny<ArraySegment<byte>>(),
          It.IsAny<CancellationToken>()
        ));
        mockSocket.Verify(o => o.CloseAsync(
          WebSocketCloseStatus.Empty,
          closingReceiveResultMessage,
          It.IsAny<CancellationToken>()
        ));
    }

    [Fact]
    public async void ShouldEchoToSocketAndCloseAfterIteration()
    {
        // Given
        var calls = 0;
        var mockSocket = new Mock<WebSocket>();
        mockSocket.Setup(o => o.ReceiveAsync(
            It.IsAny<ArraySegment<byte>>(),
            It.IsAny<CancellationToken>()
          )
        ).Callback(() => calls++)
        .Returns(() =>
          {
              if (calls == 1)
                  return
                Task.FromResult<WebSocketReceiveResult>(
                  continuingWebSocketReceiveResult
                );
              return
            Task.FromResult<WebSocketReceiveResult>(
              closingWebSocketReceiveResult
            );
          }
        );
        // When
        await service.Echo(mockSocket.Object);
        // Then
        mockSocket.Verify(o => o.ReceiveAsync(
          It.IsAny<ArraySegment<byte>>(),
          It.IsAny<CancellationToken>()
        ), Times.Exactly(2));
        mockSocket.Verify(o => o.CloseAsync(
          WebSocketCloseStatus.Empty,
          closingReceiveResultMessage,
          It.IsAny<CancellationToken>()
        ));
        mockSocket.Verify(o => o.SendAsync(
          It.IsAny<ArraySegment<byte>>(),
          It.IsAny<WebSocketMessageType>(),
          true,
          default
        ));
        Assert.Equal(2, calls);
    }
    [Fact]
    public async void ShouldStreamTweetsWithDeafultCancellationToken()
    {
        // Given
        var calls = 0;
        var mockSocket = new Mock<WebSocket>();

        mockSocket.Setup(o => o.ReceiveAsync(
            It.IsAny<ArraySegment<byte>>(),
            It.IsAny<CancellationToken>()
          )
        ).Callback(() => calls++)
        .Returns(() =>
          {
              if (calls == 1)
                  return
                Task.FromResult<WebSocketReceiveResult>(
                  continuingWebSocketReceiveResult
                );
              return
            Task.FromResult<WebSocketReceiveResult>(
              closingWebSocketReceiveResult
            );
          }
        );
        // When
        await service.StreamTweets(mockSocket.Object);
        // Then
        mockSocket.Verify(o => o.ReceiveAsync(
            It.IsAny<ArraySegment<byte>>(),
            It.IsAny<CancellationToken>()
            ),
            Times.Exactly(2)
        );
    }
       [Fact]
    public async void ShouldStreamTweetsWithNonDeafultCancellationToken()
    {
        // Given
        var cancellationTokenSource = new CancellationTokenSource();
        var calls = 0;
        var mockSocket = new Mock<WebSocket>();

        mockSocket.Setup(o => o.ReceiveAsync(
            It.IsAny<ArraySegment<byte>>(),
            It.IsAny<CancellationToken>()
          )
        ).Callback(() => calls++)
        .Returns(() =>
          {
              if (calls == 1)
                  return
                Task.FromResult<WebSocketReceiveResult>(
                  continuingWebSocketReceiveResult
                );
              return
            Task.FromResult<WebSocketReceiveResult>(
              closingWebSocketReceiveResult
            );
          }
        );
        // When
        await service.StreamTweets(mockSocket.Object, cancellationTokenSource.Token);
        // Then
        mockSocket.Verify(o => o.ReceiveAsync(
            It.IsAny<ArraySegment<byte>>(),
            It.IsAny<CancellationToken>()
            ),
            Times.Exactly(2)
        );
    }
}
