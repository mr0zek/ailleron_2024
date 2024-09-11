using DocFlow.Application;
using DocFlow.Domain.Documents;
using System;

namespace DocFlow.WebApp.Features.CreateDocument
{
  public class PostCreateDocumentRequest 
  {
    public string DocumentType { get; set; }
    public string CreatorId { get; set; }
    public string Title { get; set; }
  }
}