using DocFlow.Domain.Documents;
using System;
using System.Collections.Generic;

namespace DocFlow.Infrastructure.Repo
{
  public class FakeDocumentRepository : IDocumentRepository
  {
    private static IDictionary<string, Document> fakeDatabase = new Dictionary<string, Document>();

    public void Save(Document document)
    {
      fakeDatabase[document.Id] = document;
    }
    
    public Document Get(string id)
    {
      return fakeDatabase[id];
    }

    public IEnumerable<Document> GetAll()
    {
      return fakeDatabase.Values;
    }
  }
}