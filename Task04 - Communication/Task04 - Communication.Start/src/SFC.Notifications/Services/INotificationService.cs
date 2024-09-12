using SFC.Notifications.Contract;
using SFC.SharedKernel;
using System.Collections.Generic;

namespace SFC.Notifications.Services
{
  public interface INotificationService
  {
    IEnumerable<NotificationsCountResult> GetSendNotificationsCount(string notificationType, params LoginName[] loginNames);
    void SetNotificationEmail(Email email, LoginName loginName);
    void SendNotification(LoginName loginName, string title, string body, string notificationType);
  }
}

