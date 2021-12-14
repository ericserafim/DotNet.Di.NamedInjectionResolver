namespace Example.DI.NamedConvention.Services
{
  public class FakeServiceX
  {
    public const string Service = nameof(FakeServiceX);

    public string Do() => Service;
  }
}
