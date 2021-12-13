using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.DI.NamedConvention.Services
{
  public interface IService
  {
    public string Name { get; }

    string MyNameIs();
  }
}
