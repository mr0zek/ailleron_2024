using Autofac;
using DocFlow.Domain.Documents;
using DocFlow.Domain.Users;
using DocFlow.WebApp;
using Moq;
using RestEase;
using System;
using System.Threading;
using Xunit;

namespace DocFlow.Infrastructure.Repo
{
  public class IntegrationTests
  {    
    [Fact]
    [Trait("Category", "Integration")]
    public async void HappyScenario()
    {
      //Setup
      int port = 12121;
      string documentsUrl = $"http://localhost:{port}";
      string testCreatorId = "testCreator";
      string testVerifierId = "testVerifier";
      string testPublisherId = "testPublisher";
      string testTitle = "testTitle";

      Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
      userRepositoryMock.Setup(f => f.Get(testCreatorId)).Returns(new User(testCreatorId));

      var documentsApi = RestClient.For<IDocumentApi>(documentsUrl);

      Bootstrap.Run(new string[] { }, builder => { }, port);

      // Act
      var documentId = await documentsApi.CreateAsync(new CreateDocumentRequest()
      {
        CreatorId = testCreatorId,
        DocumentType = DocumentType.PROCEDURE.ToString(),
        Title = testTitle
      });

      await documentsApi.VerifyAsync(documentId, new VerifyDocumentRequest()
      {
        VerifierId = testVerifierId
      });

      await documentsApi.PublishAsync(documentId, new PublishDocumentRequest()
      {
        PublisherId = testPublisherId       
      });


    }
  }
}