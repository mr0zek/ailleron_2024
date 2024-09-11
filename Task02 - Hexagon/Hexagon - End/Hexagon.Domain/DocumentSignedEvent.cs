using System;

namespace Hexagon
{
  public class DocumentSignedEvent : IEvent
  {
    public string UserId { get; }
    public string Id { get; }
    public DateTime Created { get; }

    public DocumentSignedEvent(string userId)
    {
      UserId = userId;
      Id = Guid.NewGuid().ToString();
      Created = DateTime.Now;
    }    
  }
}