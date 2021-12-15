using Example.DI.NamedConvention.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Example.DI.NamedConvention
{
  public static class ServicesExtensions
  {
    /// <summary>
    /// Extension to have many implementations being resolved by name convention
    /// </summary>
    /// <typeparam name="TService">Interface</typeparam>
    /// <typeparam name="TImplementation">Class that implements the TService</typeparam>    
    /// <param name="name">Service name</param>
    /// <param name="serviceLifetime">Service life cycle</param>
    /// <returns></returns>
    public static IServiceCollection AddNamedService<TService, TImplementation>(this IServiceCollection services, string name, ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
    where TService : class where TImplementation : class, TService
    {
      switch (serviceLifetime)
      {
        case ServiceLifetime.Transient:
          {
            services.AddTransient<TImplementation>();
            break;
          }
        case ServiceLifetime.Singleton:
          {
            services.AddSingleton<TImplementation>();
            break;
          }
        case ServiceLifetime.Scoped:
          {
            services.AddScoped<TImplementation>();
            break;
          }
        default:
          throw new ArgumentOutOfRangeException(nameof(serviceLifetime), serviceLifetime, "Invalid Service Lifetime.");
      }

      // Registering how the service will be retrieved.
      NamedServiceCollection.AddService<TService, TImplementation>(name);

      //Always Transient to avoid different life cycles between Console Apps and Web APIs      
      services.AddTransient<IServiceResolver<TService>>(sp => serviceName => NamedServiceCollection.GetService<TService>(serviceName, sp));

      return services;
    }
  }
}
