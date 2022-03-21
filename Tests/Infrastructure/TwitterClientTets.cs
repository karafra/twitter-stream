using Infrastructure.Twitter;
using Moq;
using Xunit;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Tests.Infrastructure;

public sealed class TwitterClientTests
{
  private const string BEARER_TOKEN = "bearerToken";

  private const string NOT_BEARER_TOKEN = "notBearerToken";

  private static Dictionary<string, string> inMememoryConfigPass = 
    new Dictionary<string, string> { { "twitter:bearer", BEARER_TOKEN} };

  private IConfiguration mockConfiguration = new ConfigurationBuilder()
    .AddInMemoryCollection(inMememoryConfigPass).Build();

  private Mock<IConfigurationRoot> mockConfigurationRoot = new();

  private Mock<TwitterSharp.Client.TwitterClient> mockTwitterSharpClient = new();

  [Fact]
  public void ShouldCreateClient()
  {
    // Given
    // When
    TwitterClient twitterClient = new TwitterClient(
      (IConfigurationRoot) mockConfiguration
    );
    // Then
    Assert.NotNull(twitterClient);
  }
}