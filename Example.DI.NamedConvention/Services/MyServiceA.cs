using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.DI.NamedConvention.Services
{
  public class MyServiceA : IService
  {
    public string Name => "ServiceA";

    public string MyNameIs() => nameof(MyServiceA);
  }
}
