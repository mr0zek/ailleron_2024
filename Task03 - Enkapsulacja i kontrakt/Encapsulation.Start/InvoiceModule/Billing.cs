namespace InvoiceModule
{
  public class Billing
  {
    private IEnumerable<Item> _items = new List<Item>();

    public Billing(IEnumerable<Item> items)
    {
      _items = items;
      Sum = items.Sum(f => f.Price);
    }

    public int Sum { get; private set; }    
  }
}