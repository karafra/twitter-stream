using Infrastructure;
using Application;

namespace Presentation;


/// <summary>
/// Starter class
/// </summary>
internal sealed class Startup
{

  /// <summary>
  /// Root of configuration
  /// </summary>
  public IConfigurationRoot Configuration { get; }

  public Startup()
  {
    var builder = new ConfigurationBuilder();
    builder.SetBasePath(
      AppContext.BaseDirectory
    );
    builder.AddYamlFile("configuration.yml");
    Configuration = builder.Build();
  }

  /// <summary>
  /// Mounts services to service collection
  /// </summary>
  /// <param name="services">Service collection to mount services to</param>
  public void ConfigureServices(IServiceCollection services)
  {
    services.AddLogging(config => {
      config.AddDebug();
      config.AddConsole();
    });
    services.AddSingleton<IConfigurationRoot>(Configuration);
    services.AddTwitterClient();
    services.MountApplication();
    services.AddRazorPages();
    services.AddHttpContextAccessor();
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
  }

  /// <summary>
  /// Configures mounted services on application level
  /// </summary>
  /// <param name="app">App on which services are configured</param>
  public void Configure(IApplicationBuilder app)
  {
    app.UseWebSockets(new WebSocketOptions
    {
      KeepAliveInterval = TimeSpan.FromMinutes(1),
   });
    app.UseStaticFiles();
    app.UseRouting();
    app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      }
    );
    app.UseSwagger();
    app.UseSwaggerUI();
  }
}
