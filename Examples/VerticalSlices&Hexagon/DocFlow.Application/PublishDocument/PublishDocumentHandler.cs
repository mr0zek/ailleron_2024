using DocFlow.Domain.Documents;
using System;
using DocFlow.Domain.Documents.Cost;

namespace DocFlow.Application.PublishDocument
{
  public class PublishDocumentHandler : ICommandHandler<PublishDocumentCommand>
  {
    private IDocumentRepository _documentRepo;
    private ICostCalculatorFactory _costCalculatorFactory;

    public PublishDocumentHandler(IDocumentRepository documentRepo, ICostCalculatorFactory costCalculatorFactory)
    {
      _documentRepo = documentRepo;
      _costCalculatorFactory = costCalculatorFactory;
    }

    public void Handle(PublishDocumentCommand command)
    {
      Document document = _documentRepo.Get(command.Id);

      ICostCalculator calculator = _costCalculatorFactory.Create();

      document.Publish(calculator);

      _documentRepo.Save(document);
    }
  }
}