using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TwitterSharp.Rule;
using TwitterSharp.Request;

namespace Infrastructure.Twitter;

/// <summary>
/// baseclass for twitter client
/// </summary>
public class TwitterClient : TwitterSharp.Client.TwitterClient
{ 
  /// <summary>
  /// Configuration section of twitter client
  /// </summary> 
  private readonly IConfigurationSection _configuration;

  private readonly ILogger _logger;

  /// <summary>
  /// Basic dependency injection constructor that creates authorized client.
  /// </summary>
  /// <param name="configuration">Root configuration file</param> 
  public TwitterClient(
    IConfigurationRoot configuration,
    ILogger<TwitterClient> logger)
   :
  base(configuration.GetSection("twitter").GetValue<string>("bearerToken"))
  {
    // Configuration for possible extension of this class
    _configuration = configuration.GetSection("twitter");
    _logger = logger;
    var request = new StreamRequest(
      Expression.Hashtag(_configuration.GetValue<string>("hashtag", ""))
    );
    AddTweetStreamAsync(request);
  }
}
