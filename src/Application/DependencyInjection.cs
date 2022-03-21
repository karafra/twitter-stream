using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
namespace Application;

public static class Application
{
  public static IServiceCollection MountApplication(this IServiceCollection services)
  {
    return services;
  }
}