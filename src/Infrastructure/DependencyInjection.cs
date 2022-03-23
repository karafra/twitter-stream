using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Twitter;

namespace Infrastructure;
public static class DependencyInjection
{
  public static IServiceCollection AddTwitterClient(this IServiceCollection services)
  {
    services.AddSingleton<TwitterSharp.Client.TwitterClient, TwitterClient>();
    return services;
  }
}