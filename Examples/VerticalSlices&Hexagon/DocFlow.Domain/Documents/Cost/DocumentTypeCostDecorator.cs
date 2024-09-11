using DocFlow.Domain.Shared;

namespace DocFlow.Domain.Documents.Cost
{
  public class DocumentTypeCostDecorator : BaseCostDecorator
  {
    private readonly DocumentType _type;
    private readonly int _costIncreasePercentage;
    
    public DocumentTypeCostDecorator(ICostCalculator calc, DocumentType type, int costIncreasePercentage)
      : base(calc)
    {
      _type = type;
      _costIncreasePercentage = costIncreasePercentage;      
    }

    public override Money Calculate(Document doc)
    {
      Money result = _decorated.Calculate(doc);
      if (doc.Type == _type)
      {
        return result.MultiplyBy(((double)100+_costIncreasePercentage)/100);
      }

      return result;
    }
  }
}