namespace Example.DI.NamedConvention.Services
{
  public delegate TResult IServiceResolver<TResult>(dynamic serviceName);
}
