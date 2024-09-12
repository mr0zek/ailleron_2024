using SFC.Infrastructure.Interfaces;
using SFC.Notifications.Contract;
using System.Collections.Generic;

namespace SFC.Tests
{
  internal class NotificationSentEventHandler : IEventHandler<NotificationSentEvent>
  {
    public static List<NotificationSentEvent> NotificationSentEvents = new List<NotificationSentEvent>();
    public void Handle(NotificationSentEvent @event)
    {
      NotificationSentEvents.Add(@event);
    }
  }
}