namespace Hexagon
{
  public interface IDocumentService
  {
    void Create(string id);
    void Sign(string id, string userId);
    void Archive(string id);
  }
}