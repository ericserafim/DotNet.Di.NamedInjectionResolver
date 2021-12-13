using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.DI.NamedConvention.Services
{
  [AttributeServiceName("ServiceA")]
  public class MyServiceA : IService
  {
    public string Name => nameof(MyServiceA);

    public string MyNameIs() => nameof(MyServiceA);
  }
}
