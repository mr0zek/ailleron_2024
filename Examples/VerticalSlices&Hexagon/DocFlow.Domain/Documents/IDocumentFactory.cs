using DocFlow.Domain.Users;

namespace DocFlow.Domain.Documents
{
  public interface IDocumentFactory
  {
    Document Create(string id, DocumentType type, User creator);
  }
}