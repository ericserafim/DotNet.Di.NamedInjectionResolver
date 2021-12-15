using Example.DI.NamedConvention.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
      //services.AddServicesByName<IService, string>(constantName: "Name");
      //services.AddServicesByName<IDummyService, int>(constantName: "ServiceName");
      //services.AddServicesByName<FakeServiceX, string>(constantName: "Service");

      services.AddNamedService<IService, MyServiceA>("ServiceA", ServiceLifetime.Transient);
      services.AddNamedService<IService, MyServiceB>("ServiceB", ServiceLifetime.Scoped);
      services.AddNamedService<IService, MyServiceC>("ServiceC", ServiceLifetime.Singleton);

      services.AddNamedService<IDummyService, DummyService1>("ServiceA", ServiceLifetime.Scoped);
      services.AddNamedService<IDummyService, DummyService2>("ServiceB", ServiceLifetime.Scoped);

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
