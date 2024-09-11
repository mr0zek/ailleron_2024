namespace DocFlow.Domain.Documents.Validation.chain
{
  public interface IDocumentCriterion
  {
    bool CanCheck(DocumentStatus desiredStatus);

    DocumentProblem Check(Document document);
  }
}