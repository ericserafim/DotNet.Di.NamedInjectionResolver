using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.DI.NamedConvention.Services
{
  public class MyServiceC : IService
  {
    public string Name => "ServiceC";

    public string MyNameIs() => nameof(MyServiceC);
  }
}
