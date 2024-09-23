namespace InvoiceModule
{
  public class Invoice
  {
    public Invoice(string clientId, int price)
    {
      ClientId = clientId;
      Price = price;
    }

    public string ClientId { get; }
    public int Price { get; }
  }
}