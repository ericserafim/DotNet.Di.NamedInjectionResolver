using Example.DI.NamedConvention.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Reflection;

namespace Example.DI.NamedConvention
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    
    public void ConfigureServices(IServiceCollection services)
    {
      foreach (var type in Assembly.GetEntryAssembly().GetTypes().Where(t => t.IsClass && t.IsAssignableTo(typeof(IService))))
      {
        services.AddScoped(typeof(IService), type);
      }
      services.AddScoped<IServiceResolver>(sp => serviceName => sp.GetServices<IService>().Single(s => s.Name == serviceName));
      
      services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
