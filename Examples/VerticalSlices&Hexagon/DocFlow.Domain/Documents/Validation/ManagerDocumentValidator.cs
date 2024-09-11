using System.Collections.Generic;

namespace DocFlow.Domain.Documents.Validation.chain
{
  public class ManagerDocumentValidator : IDocumentValidator
  {
    private IList<IDocumentCriterion> _criterions = new List<IDocumentCriterion>();

    public void AddCritetion(IDocumentCriterion criterion)
    {
      _criterions.Add(criterion);
    }

    public ValidationResult Validate(Document document, DocumentStatus desiredStatus)
    {
      ValidationResult result = new ValidationResult();
      foreach (IDocumentCriterion documentCriterion in _criterions)
      {
        if (documentCriterion.CanCheck(desiredStatus))
        {
          var check = documentCriterion.Check(document);
          if (check != null)
          {
            result.Add(check);
          }
        }
      }
      return result;
    }
  }
}