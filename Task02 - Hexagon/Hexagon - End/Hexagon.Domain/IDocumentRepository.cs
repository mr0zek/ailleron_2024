namespace Hexagon
{
  public interface IDocumentRepository
  {
    void Save(Document document);
    Document Get(string id);
  }
}