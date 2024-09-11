using System.Collections.Generic;

namespace Hexagon
{
  class InMemoryDocumentRepository : IDocumentRepository
  {
    private IDictionary<string, Document> _items = new Dictionary<string, Document>();

    public void Save(Document document)
    {
      _items[document.Id] = document;
    }

    public Document Get(string id)
    {
      return _items[id];
    }
  }
}