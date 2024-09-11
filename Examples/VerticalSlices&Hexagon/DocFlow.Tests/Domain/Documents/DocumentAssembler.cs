using DocFlow.Domain.Documents;
using DocFlow.Domain.Documents.Validation;
using DocFlow.Domain.Users;
using Moq;
using System;

namespace DocFlow.Infrastructure.Repo
{
  public class DocumentAssembler
  {
    private DocumentType type = DocumentType.PROCEDURE;
    private User author = new User(Guid.NewGuid().ToString());
    private Mock<IDocumentValidator> _documentValidatorMock = new Mock<IDocumentValidator>();

    public Document Build()
    {
      return new Document(Guid.NewGuid().ToString(), type, author, new DocumentNumber("1"), _documentValidatorMock.Object);
    }

    public DocumentAssembler Published()
    {
      //TODO
      return this;
    }

    public void IsVerified()
    {
      //Document document = new Document(TYPE, CREATOR, new DocumentNumber("1"), _documentValidatorMock.Object);
      //document.Verify(VERIFIER);
    }
  }
}