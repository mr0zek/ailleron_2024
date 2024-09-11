using System;
using DocFlow.Domain.Documents;
using DocFlow.Domain.Users;

namespace DocFlow.Application.VerifyDocument
{
  public class VerifyDocumentHandler : ICommandHandler<VerifyDocumentCommand>
  {
    private IDocumentRepository _documentRepo;
    private IUserRepository _userRepo;

    public VerifyDocumentHandler(IUserRepository userRepo, IDocumentRepository documentRepo)
    {
      _userRepo = userRepo;
      _documentRepo = documentRepo;
    }

    public void Handle(VerifyDocumentCommand command)
    {
      Document document = _documentRepo.Get(command.Id);
      User verifier = _userRepo.Get(command.VerifierId);

      document.Verify(verifier);

      _documentRepo.Save(document);     
    }
  }
}