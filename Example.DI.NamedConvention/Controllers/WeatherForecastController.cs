using Example.DI.NamedConvention.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Example.DI.NamedConvention.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class WeatherForecastController : ControllerBase
  {
    private readonly IServiceResolver _serviceResolver;

    public WeatherForecastController(IServiceResolver serviceResolver)
    {
      _serviceResolver = serviceResolver;
    }

    [HttpGet]
    public string Get(string name)
    {
      return _serviceResolver(name).MyNameIs();
    }
  }
}
