namespace Example.DI.NamedConvention.Services
{  
  public class MyServiceB : IService
  {    
    public const string Name = "ServiceB";

    public string MyNameIs() => nameof(MyServiceB);
  }
}
