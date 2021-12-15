using Example.DI.NamedConvention.Services;
using Microsoft.AspNetCore.Mvc;

namespace Example.DI.NamedConvention.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class WeatherForecastController : ControllerBase
  {
    private readonly IServiceResolver<IService> _serviceResolver;
    private readonly IServiceResolver<IDummyService> _dummyServiceResolver;
    private readonly IServiceResolver<FakeServiceX> _fakeServiceResolver;

    public WeatherForecastController(IServiceResolver<IService> serviceResolver,
      IServiceResolver<IDummyService> serviceDummyResolver
      //IServiceResolver<FakeServiceX> fakeServiceResolver
      )
    {
      _serviceResolver = serviceResolver;
      _dummyServiceResolver = serviceDummyResolver;
      //_fakeServiceResolver = fakeServiceResolver;
    }

    [HttpGet]
    public string Get(string serviceName, string serviceDummyName, string fakeServiceName)
    {
      return $"{_serviceResolver(serviceName).MyNameIs()}\n{_dummyServiceResolver(serviceDummyName).DoSomething()}";

      //return $"{_serviceResolver(serviceName).MyNameIs()}\n{_dummyServiceResolver(serviceDummyName).DoSomething()}\n{_fakeServiceResolver(fakeServiceName).Do()}";
    }
  }
}
