namespace Example.DI.NamedConvention.Services
{
  public class DummyService1 : IDummyService
  {
    public const int ServiceName = 1;

    public string DoSomething() => nameof(DummyService1);
  }
}
