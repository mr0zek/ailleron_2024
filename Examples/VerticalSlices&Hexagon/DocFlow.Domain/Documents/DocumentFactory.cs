using DocFlow.Domain.Documents.Numbers;
using DocFlow.Domain.Documents.Validation.chain;
using DocFlow.Domain.Users;
using System;

namespace DocFlow.Domain.Documents
{
  public class DocumentFactory : IDocumentFactory
  {
    private INumberGeneratorFactory _numberGeneratorFactory;

    public DocumentFactory(INumberGeneratorFactory numberGeneratorFactory)
    {
      _numberGeneratorFactory = numberGeneratorFactory;
    }

    public Document Create(string id, DocumentType type, User author)
    {
      var generator = _numberGeneratorFactory.Create(new ConfigurationData());
      return new Document(id, type, author, generator.Generate(), new ManagerDocumentValidator());
    }
  }
}