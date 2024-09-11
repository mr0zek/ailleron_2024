using DocFlow.Domain.Documents.Validation.chain;

namespace DocFlow.Domain.Documents.Validation.Criteria.QEP
{
  public class BodyValidator : BaseCriterion
  {
    public BodyValidator(DocumentStatus supportedStatus)
      : base(supportedStatus)
    {
    }

    public override DocumentProblem Check(Document document)
    {
      if (document.Body != null)
      {
        return new DocumentProblem("Body not set", ProblemSeverity.STANDARD);
      }
      return null;
    }
  }
}