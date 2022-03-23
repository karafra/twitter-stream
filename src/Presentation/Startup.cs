using Infrastructure;
using Application;

namespace Presentation;


/// <summary>
/// Starter class
/// </summary>
internal sealed class Startup
{

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

  public void ConfigureServices(IServiceCollection services)
  {
    services.AddLogging();
    services.AddSingleton<IConfigurationRoot>(Configuration);
    services.AddTwitterClient();
    services.MountApplication();
    services.AddRazorPages();
    services.AddHttpContextAccessor();
    services.AddControllers();
  }

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
  }
}
