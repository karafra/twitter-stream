using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Application.Contracts;
using Application.Services;
namespace Application;

public static class Application
{
  public static IServiceCollection MountApplication(this IServiceCollection services)
  {
    services.AddScoped<IWebSocketService, WebSocketService>();
    return services;
  }
}