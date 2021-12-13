using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.DI.NamedConvention.Services
{
  [AttributeServiceName("ServiceB")]
  public class MyServiceB : IService
  {
    public string Name => nameof(MyServiceA);

    public string MyNameIs() => nameof(MyServiceB);
  }
}
