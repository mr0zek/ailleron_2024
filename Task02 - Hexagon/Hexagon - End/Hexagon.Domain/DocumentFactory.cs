namespace Hexagon
{
  class DocumentFactory : IDocumentFactory
  {
    private readonly ISignatureCalculator _signatureCalculator;
    private readonly IEventPublisher _eventPublisher;

    public DocumentFactory(ISignatureCalculator signatureCalculator, IEventPublisher eventPublisher)
    {
      _signatureCalculator = signatureCalculator;
      _eventPublisher = eventPublisher;
    }

    public Document Create(string id)
    {
      string signature = _signatureCalculator.Calculate(id);
      return new Document(id, signature, _eventPublisher);
    }
  }
}