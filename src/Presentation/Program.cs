using Microsoft.AspNetCore;

namespace Presentation;

/// <summary>
/// Runner class.
/// </summary>
public sealed class Program
{
  /// <summary>
  /// Runner method.
  /// </summary>
  /// <param name="args">Command line arguments</param>
  public static async Task Main(string[] args) => await RunAsync(args);

  /// <summary>
  /// Run application in async mode.
  /// </summary>
  /// <param name="args">Command line arguments</param>
  /// <returns>Task runing the server</returns>
  public static Task RunAsync(string[] args)
  {
    return BuildHost(args).RunAsync();
  }

  /// <summary>
  /// Builds web host.
  /// </summary>
  /// <param name="args">Command line argumets</param>
  /// <returns>Built webhost</returns>
  public static IWebHost BuildHost(string[] args)
  {
    var builder = WebHost.CreateDefaultBuilder();
    builder.UseWebRoot(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"));
    builder.UseStartup<Startup>();
    builder.UseUrls(Environment.GetEnvironmentVariable("ASPNETCORE_URLS") ?? "http://localhost:5000/");
    return builder.Build();
  }
}
