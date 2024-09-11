using DocFlow.Domain.Documents;
using DocFlow.Domain.Users;

namespace DocFlow.Application.CreateDocument
{
  public class CreateDocumentHandler : ICommandHandler<CreateDocumentCommand>
  {
    private IUserRepository _userRepo;
    private IDocumentFactory _documentFactory;
    private IDocumentRepository _documentRepo;

    public CreateDocumentHandler(IUserRepository userRepo, IDocumentFactory documentFactory, IDocumentRepository documentRepo)
    {
      _userRepo = userRepo;
      _documentFactory = documentFactory;
      _documentRepo = documentRepo;
    }

    public void Handle(CreateDocumentCommand command)
    {
      User creator = _userRepo.Get(command.CreatorId);

      Document document = _documentFactory.Create(command.Id, command.DocumentType, creator);

      document.ChangeTitle(command.Title);

      _documentRepo.Save(document);      
    }
  }
}