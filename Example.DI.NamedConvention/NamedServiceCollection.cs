using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Example.DI.NamedConvention
{
  public static class NamedServiceCollection
  {
    private static Dictionary<Type, Dictionary<string, Func<IServiceProvider, object>>> TypesMapping { get; }
      = new Dictionary<Type, Dictionary<string, Func<IServiceProvider, object>>>();

    public static void AddService<TService, TImplementation>(string name) where TService : class where TImplementation : class, TService
    {
      AddServiceDescriptor(typeof(TService), typeof(TImplementation), name);
    }

    public static void AddService(Type serviceType, Type implementation, string name)
    {
      AddServiceDescriptor(serviceType, implementation, name);
    }

    private static void AddServiceDescriptor(Type serviceType, Type implementation, string name)
    {
      if (TypesMapping.TryGetValue(serviceType, out var dict))
      {
        dict.TryAdd(name, sp => sp.GetRequiredService(implementation));
        return;
      };

      dict = new Dictionary<string, Func<IServiceProvider, object>>();
      dict.TryAdd(name, sp => sp.GetRequiredService(implementation));
      TypesMapping.Add(serviceType, dict);
    }

    public static TService GetService<TService>(string name, IServiceProvider serviceProvider) where TService : class
    {
      if (TypesMapping.TryGetValue(typeof(TService), out var dict))
      {
        if (dict.TryGetValue(name, out Func<IServiceProvider, object> service))
        {
          return (TService)service(serviceProvider);
        }
      }

      throw new TypeAccessException($"No service named '{name}' for the type {typeof(TService)} was found.");
    }
  }
}