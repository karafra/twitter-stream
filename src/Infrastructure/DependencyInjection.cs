using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Twitter;

namespace Infrastructure;

/// <summary>
/// DI for Infrastructure layer 
/// </summary>
public static class DependencyInjection
{
  /// <summary>
  /// Configures services of infrastructure layer
  /// </summary>
  /// <param name="services">Service collection application</param>
  /// <returns>Configured collection</returns>
  public static IServiceCollection AddTwitterClient(this IServiceCollection services)
  {
    services.AddSingleton<TwitterSharp.Client.TwitterClient, TwitterClient>();
    return services;
  }
}
