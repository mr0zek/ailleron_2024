using DocFlow.Domain.Shared;

namespace DocFlow.Domain.Documents.Cost
{
  public abstract class BaseCostDecorator : ICostCalculator
  {
    protected ICostCalculator _decorated;

    protected BaseCostDecorator(ICostCalculator decorated)
    {
      _decorated = decorated;
    }

    public abstract Money Calculate(Document doc);
  }
}
