using DocFlow.Domain.Documents;
using DocFlow.Domain.Documents.Validation;
using DocFlow.Domain.Users;
using Moq;
using System;
using Xunit;

namespace DocFlow.Infrastructure.Repo
{
  public class DocumentSpec
  {
    private DocumentAssembler _documentAssembler = new DocumentAssembler();
    private Document _document;
    private static DocumentType TYPE = DocumentType.PROCEDURE;
    private static User CREATOR = new User(Guid.NewGuid().ToString());
    private static User VERIFIER = new User(Guid.NewGuid().ToString());
    private Mock<IDocumentValidator> _documentValidatorMock = new Mock<IDocumentValidator>();

    [Fact]
    public void Can_Not_Verify_By_Author()
    {
      // Arrange
      Document document = new Document(Guid.NewGuid().ToString(), TYPE, CREATOR, new DocumentNumber("1"), _documentValidatorMock.Object);

      // Act, Assert
      Assert.Throws<DocumentOpeartionException>(() => document.Verify(CREATOR));
    }

    [Fact]
    public void Should_Back_To_Verified_When_Changing_Title()
    {
      // Arrange
      //TODO zamienic na Assembler
      Document document = new Document(Guid.NewGuid().ToString(), TYPE, CREATOR, new DocumentNumber("1"), _documentValidatorMock.Object);
      document.ChangeTitle("title 1");
      document.Verify(VERIFIER);
      //when
      document.ChangeTitle("title 2");
      // Act
      //TODO zamienic na AssertObject
      Assert.Equal(DocumentStatus.DRAFT, document.Status);
    }

    //[Fact]
    //public void Should_Publish_Verified()
    //{
    //  // Arrange
    //  //TODO zamienic na Assembler

    //  ArrangeDocument().IsVerified().WithTitle("4563").WithNumber("443245");

    //  ActOnDocument().Publish();

    //  AssertDocument().IsPublished();

    //  //when
    //  document.Publish(null);
    //  // Act
    //  //TODO zamienic na AssertObject
    //  Assert.AreEqual(DocumentStatus.PUBLISHED, document.Status);
    //}

    private DocumentAssert AssertDocument()
    {
      return new DocumentAssert(_document);
    }

    private Document ActOnDocument()
    {
      _document = _documentAssembler.Build();
      return _document;
    }

    private DocumentAssembler ArrangeDocument()
    {
      return _documentAssembler;
    }
  }
}