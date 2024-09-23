using SFC.Infrastructure.Interfaces;
using SFC.SharedKernel;
using System.Collections.Generic;

namespace SFC.Notifications.Features.NotificationQuery
{
  public class GetSendNotificationsCountRequest : IRequest<IEnumerable<NotificationsCountResult>>
  {
    public string NotificationType { get; set; }
    public LoginName[] LoginNames { get; set; }
  }
}
