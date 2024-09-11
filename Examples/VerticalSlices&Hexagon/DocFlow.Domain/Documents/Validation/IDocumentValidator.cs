using System.Collections.Generic;

namespace DocFlow.Domain.Documents.Validation
{
  public interface IDocumentValidator
  {
    ValidationResult Validate(Document document, DocumentStatus desiredStatus);
  }
}