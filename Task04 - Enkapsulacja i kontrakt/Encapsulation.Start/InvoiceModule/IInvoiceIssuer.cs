namespace InvoiceModule
{
  public interface IInvoiceIssuer
  {
    Invoice Issue(string clientId, Billing billing);
  }
}