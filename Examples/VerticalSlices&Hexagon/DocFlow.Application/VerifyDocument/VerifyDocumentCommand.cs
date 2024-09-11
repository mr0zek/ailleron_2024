using System;

namespace DocFlow.Application.VerifyDocument
{
  public class VerifyDocumentCommand
  {
    public string Id { get; private set; }

    public string VerifierId { get; private set; }

    public VerifyDocumentCommand(string id, string verifierId)
    {
      VerifierId = verifierId;
      Id = id;
    }
  }
}

