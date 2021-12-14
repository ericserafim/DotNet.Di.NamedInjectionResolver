namespace Example.DI.NamedConvention.Services
{
  public class MyServiceC : IService
  {    
    public const string Name = "ServiceC";

    public string MyNameIs() => nameof(MyServiceC);
  }
}
