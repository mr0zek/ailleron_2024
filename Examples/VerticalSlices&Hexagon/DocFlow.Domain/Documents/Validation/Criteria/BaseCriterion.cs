using System.Collections.Generic;

namespace DocFlow.Domain.Documents.Validation.chain
{
  public abstract class BaseCriterion : IDocumentCriterion
  {
    private DocumentStatus _supportedStatus;

    public BaseCriterion(DocumentStatus supportedStatus)
    {
      _supportedStatus = supportedStatus;
    }

    public bool CanCheck(DocumentStatus desiredStatus)
    {
      return _supportedStatus == desiredStatus;
    }

    public abstract DocumentProblem Check(Document document);
  }
}