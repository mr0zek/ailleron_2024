namespace InvoiceModule
{
  public class InvoiceIssuer : IInvoiceIssuer
  {
    private IDiscountCalculator _discountCalculator;

    public InvoiceIssuer(IDiscountCalculator discountCalculator)
    {
      _discountCalculator = discountCalculator;
    }

    public Invoice Issue(string clientId, Billing billing)
    {
      if (billing.Sum > 100)
      {
        return new Invoice(clientId, billing.Sum - _discountCalculator.Calculate());
      }

      return new Invoice(clientId, billing.Sum);
    }
  }
}