namespace Example.DI.NamedConvention.Services
{
  public class DummyService2 : IDummyService
  {
    public const int ServiceName = 2;

    public string DoSomething() => nameof(DummyService2);
  }
}
