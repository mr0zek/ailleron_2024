namespace InvoiceModule.Tests
{
  internal class FakeDisscountCalculator : IDiscountCalculator
  {
    private int _discount;

    public FakeDisscountCalculator(int discount)
    {
      _discount = discount;
    }

    public int Calculate()
    {
      return _discount;
    }
  }
}