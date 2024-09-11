using DocFlow.Domain.Shared;

namespace DocFlow.Domain.Documents.Cost
{
  internal class BwCostCalulator : ICostCalculator
  {
    public Money Calculate(Document document)
    {
      return new Money(12d);
    }
  }
}