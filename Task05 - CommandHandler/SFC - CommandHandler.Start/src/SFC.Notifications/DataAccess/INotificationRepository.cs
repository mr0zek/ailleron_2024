using System;
using System.Collections.Generic;
using SFC.Notifications.Services;
using SFC.SharedKernel;

namespace SFC.Notifications.DataAccess
{
  internal interface INotificationRepository 
  {
    void Add(Email email, string title, string body, DateTime date, LoginName loginName, string notificationType);
    IEnumerable<NotificationsCountResult> GetSendNotificationsCount(
      string notificationType,
      params LoginName[] loginNames);
  }
}