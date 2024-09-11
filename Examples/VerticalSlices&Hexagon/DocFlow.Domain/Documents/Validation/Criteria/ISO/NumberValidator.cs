using DocFlow.Domain.Documents.Validation.chain;

namespace DocFlow.Domain.Documents.Validation.Criteria.ISO
{
  public class NumberValidator : BaseCriterion
  {
    public NumberValidator(DocumentStatus supportedStatus)
      : base(supportedStatus)
    {
    }

    public override DocumentProblem Check(Document document)
    {
      if (document.Number == null)
      {
        return new DocumentProblem("Number not set", ProblemSeverity.STANDARD);
      }
      return null;
    }
  }
}