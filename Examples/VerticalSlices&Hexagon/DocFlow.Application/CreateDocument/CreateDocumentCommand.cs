using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocFlow.Domain.Documents;

namespace DocFlow.Application.CreateDocument
{
  public class CreateDocumentCommand
  {
    public CreateDocumentCommand(string id, string creatorId, DocumentType documentType, string title)
    {
      Id = id;
      CreatorId = creatorId;
      DocumentType = documentType;
      Title = title;
    }

    public string Id { get; }
    public string CreatorId { get; }

    public DocumentType DocumentType { get; }

    public string Title { get; }    
  }
}