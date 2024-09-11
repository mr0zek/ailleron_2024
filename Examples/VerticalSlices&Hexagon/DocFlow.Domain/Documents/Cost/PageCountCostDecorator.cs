using DocFlow.Domain.Shared;

namespace DocFlow.Domain.Documents.Cost
{
  public class PageCountCostDecorator : BaseCostDecorator
  {
    private readonly int _pageCount;
    private readonly Money _costIncrease;

    public PageCountCostDecorator(ICostCalculator calc, int pageCount, Money costIncrease)
      : base(calc)
    {
      _pageCount = pageCount;
      _costIncrease = costIncrease;
    }

    public override Money Calculate(Document doc)
    {
      Money result = _decorated.Calculate(doc);
      if (doc.PageCount > _pageCount)
      {
        return result.Add(_costIncrease);
      }

      return result;
    }
  }
}