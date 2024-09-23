namespace InvoiceModule
{
  public class Item
  {
    public Item(int productId, int price)
    {
      ProductId = productId;
      Price = price;
    }

    public int ProductId { get; set; }
    public int Price { get; set; }
  }
}