using Example.DI.NamedConvention.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace Example.DI.NamedConvention
{
  public static class ServicesEntensions
  {
    /// <summary>
    /// Extensions to add services by using name conventions
    /// </summary>
    /// <typeparam name="TInterface">Interface or class to search for implementations to inject to Service Descriptor collection</typeparam>
    /// <typeparam name="TConstantType">Type of constant field to get the name of the service</typeparam>
    /// <param name="services">IServiceCollection to add all services descriptors</param>
    /// <param name="constantName">Name of constant field to check the service name</param>
    /// <returns></returns>
    public static IServiceCollection AddServicesByName<TInterface, TConstantType>(this IServiceCollection services, string constantName) where TInterface : class
    {
      foreach (var type in Assembly.GetEntryAssembly().GetTypes().Where(t => t.IsClass && t.IsAssignableTo(typeof(TInterface))))
      {        
        services.AddScoped(type);
      }

      services.AddScoped<IServiceResolver<TInterface>>(sp => serviceName =>
      {
        var serviceType = services.Single(s => 
          s.ServiceType.IsAssignableTo(typeof(TInterface)) &&
          s.ServiceType.GetConstantValue<TConstantType>(constantName) == serviceName);

        return (TInterface)sp.GetRequiredService(serviceType.ImplementationType);
      });

      return services;
    }

    public static TResult GetConstantValue<TResult>(this Type type, string constantName)
    {
      var result = (TResult)type.GetFields()
        .Single(fieldInfo => fieldInfo.IsLiteral && !fieldInfo.IsInitOnly && fieldInfo.Name == constantName)
        .GetRawConstantValue();

      return result;
    }
  }  
}
