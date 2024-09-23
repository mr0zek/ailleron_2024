using Autofac;

namespace InvoiceModule
{
  public class AutofacModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<DiscountCalculator>().AsImplementedInterfaces();
      builder.RegisterType<InvoiceIssuer>().AsImplementedInterfaces();
    }
  }
}