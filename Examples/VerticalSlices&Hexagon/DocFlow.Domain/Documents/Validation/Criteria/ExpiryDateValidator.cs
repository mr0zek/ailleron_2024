using DocFlow.Domain.Documents.Validation.chain;

namespace DocFlow.Domain.Documents.Validation.Criteria
{
  public class ExpiryDateValidator : BaseCriterion
  {
    public ExpiryDateValidator(DocumentStatus supportedStatus)
      : base(supportedStatus)
    {
    }

    public override DocumentProblem Check(Document document)
    {
      if (!document.ExpirationDate.HasValue)
      {
        return new DocumentProblem("ExpiryDate not set", ProblemSeverity.STANDARD);
      }
      return null;
    }
  }
}