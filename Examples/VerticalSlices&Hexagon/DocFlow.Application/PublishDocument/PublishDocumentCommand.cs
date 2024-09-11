
using System;

namespace DocFlow.Application.PublishDocument
{
  public class PublishDocumentCommand 
  {
    public string Id { get; }
    public string PublisherId { get; }

    public PublishDocumentCommand(string id, string publisherId) 
    {
      Id = id;
      PublisherId = publisherId;
    }
  }
}

