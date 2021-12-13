using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.DI.NamedConvention.Services
{
  public class MyServiceB : IService
  {
    public string Name => "ServiceB";

    public string MyNameIs() => nameof(MyServiceB);
  }
}
