using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.DI.NamedConvention.Services
{
  public class AttributeServiceName : Attribute
  {
    public string ServiceName { get; }

    public AttributeServiceName(string serviceName)
    {
      ServiceName = serviceName;
    }
  }
}
