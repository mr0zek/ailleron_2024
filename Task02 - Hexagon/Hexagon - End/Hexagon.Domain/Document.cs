namespace Hexagon
{
  public class Document
  {
    public string Id { get; }
    private readonly string _signature;
    private readonly IEventPublisher _eventPublisher;
    private string _signedByUser;
    private bool _isArchived;

    internal Document(string id, string signature, IEventPublisher eventPublisher)
    {
      _signature = signature;
      _eventPublisher = eventPublisher;
      Id = id;
    }

    public void Sign(string userId)
    {
      if (_isArchived)
      {
        throw new DocumentAlreadyArchivedException();
      }
      _signedByUser = userId;
      _eventPublisher.Publish(new DocumentSignedEvent(userId));
    }

    public void Archive()
    {
      if (_signedByUser == null)
      {
        throw new NotSignedException();
      }
      _isArchived = true;
    }
  }
}