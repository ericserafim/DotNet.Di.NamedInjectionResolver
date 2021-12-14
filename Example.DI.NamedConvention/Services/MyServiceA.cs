namespace Example.DI.NamedConvention.Services
{  
  public class MyServiceA : IService
  {    
    public const string Name = "ServiceA";

    public string MyNameIs() => nameof(MyServiceA);
  }
}
