namespace Hexagon
{
  public class DocumentService : IDocumentService
  {
    private readonly IDocumentFactory _documentFactory;
    private readonly IDocumentRepository _documentRespository;

    public DocumentService(IDocumentFactory documentFactory, IDocumentRepository documentRespository)
    {
      _documentFactory = documentFactory;
      _documentRespository = documentRespository;
    }

    public void Create(string id)
    {
      Document d = _documentFactory.Create(id);
      _documentRespository.Save(d);
    }

    public void Sign(string id, string userId)
    {
      Document d = _documentRespository.Get(id);
      d.Sign(userId);
      _documentRespository.Save(d);
    }

    public void Archive(string id)
    {
      Document d = _documentRespository.Get(id);
      d.Archive();
      _documentRespository.Save(d);
    }
  }
}
