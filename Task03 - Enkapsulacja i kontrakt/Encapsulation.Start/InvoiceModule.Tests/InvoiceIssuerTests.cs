using Autofac;
using System.Linq;
using Xunit;

namespace InvoiceModule.Tests
{
  public class InvoiceIssuerTests
  {
    [Fact]
    public void Issue_Should_calculate_discount_When_price_greather_than_100()
    {
      //var builder = new ContainerBuilder();
      //builder.RegisterModule(...);
      ///var issuer = container.Resolve<IInvoiceIssuer>();

      var issuer = new InvoiceIssuer(new DiscountCalculator());

      var invoice = issuer.Issue("CL/314242", new Billing(new[] { new Item(12, 123) }));

      Assert.True(invoice.Price == 123 - 10);
    }

    [Fact]
    public void CheckEncapsulation()
    {
      System.Type[]? types = typeof(Billing).Assembly.GetTypes();

      var allowedPublicTypes = new[] { "Billing", "Item","Invoice", "AutofacModule", "IInvoiceIssuer" };

      var incorrect = types.Where(f => f.IsPublic && !allowedPublicTypes.Any(x=>x == f.Name));


      Assert.True(incorrect.Count() == 0);
    }

  }
}