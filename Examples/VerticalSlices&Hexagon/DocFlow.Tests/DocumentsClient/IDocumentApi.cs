using RestEase;
using System.Threading.Tasks;

namespace DocFlow.Infrastructure.Repo
{
  public interface IDocumentApi
  {
    [Post("api/documents")]
    Task<string> CreateAsync([Body] CreateDocumentRequest createDocumentRequest);

    [Post("api/documents/{id}/publishers")]
    Task PublishAsync([Path]string id, [Body]PublishDocumentRequest publishDocumentRequest);

    [Post("api/documents/{id}/verifiers")]
    Task VerifyAsync([Path] string id, [Body] VerifyDocumentRequest verifyDocumentRequest);    
  }
}