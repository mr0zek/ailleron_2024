namespace DocFlow.Infrastructure.Repo
{
  public class CreateDocumentRequest
  {
    public string DocumentType { get; set; }
    public string CreatorId { get; set; }
    public string Title { get; set; }
  }
}