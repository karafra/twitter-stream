using Microsoft.Extensions.Configuration;

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

  /// <summary>
  /// Basic dependency injection constructor that creates authorized client.
  /// </summary>
  /// <param name="configuration">Root configuration file</param> 
  public TwitterClient(IConfigurationRoot configuration)
   :
  base(configuration.GetSection("twitter").GetValue<string>("bearer"))
  {
    _configuration = configuration.GetSection("twitter");
  }
}
