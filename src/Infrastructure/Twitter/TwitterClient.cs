using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
namespace Infrastructure.Twitter;

/// <summary>
/// baseclass for twitter client
/// </summary>
public sealed class TwitterClient : TwitterSharp.Client.TwitterClient
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
  public TwitterClient(IConfigurationRoot configuration, ILogger<TwitterClient> logger)
   :
  base(configuration.GetSection("twitter").GetValue<string>("bearer"))
  {
    // Configuration for possible extension of this class
    _configuration = configuration.GetSection("twitter");
    _logger = logger;
  }
}
