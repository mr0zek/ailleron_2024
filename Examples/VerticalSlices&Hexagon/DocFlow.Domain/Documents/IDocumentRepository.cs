using System;
using System.Collections.Generic;

namespace DocFlow.Domain.Documents
{
  public interface IDocumentRepository
  {
    void Save(Document document);

    Document Get(string id);    

    IEnumerable<Document> GetAll();
  }
}