using Microsoft.Extensions.Configuration;

namespace Tests.Fixtures;

/// <summary>
/// Dummy contract for teardown and setup of test methods
/// </summary>
public class BaseTestFixture : IDisposable
{
  protected IConfigurationRoot configuration;

  private const string BEARER_TOKEN = "bearerToken";

  private static Dictionary<string, string> inMememoryConfigPass = 
    new Dictionary<string, string> { 
      { "twitter:bearer", BEARER_TOKEN},
      { "twitter:hashtag", "hashtag"}
   };

  /// <summary>
  /// Setup of test method
  /// </summary>
  public BaseTestFixture()
  {
    IConfigurationRoot mockConfiguration = new ConfigurationBuilder()
    .AddInMemoryCollection(inMememoryConfigPass).Build();
    configuration = mockConfiguration;
    // Global setup before every test
  }

  /// <summary>
  /// Teardown of test method
  /// </summary>
  public virtual void Dispose()
  {
    // Global teardown before every test
  }
}