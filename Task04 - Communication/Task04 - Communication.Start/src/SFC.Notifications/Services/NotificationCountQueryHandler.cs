using SFC.Infrastructure.Interfaces;
using SFC.Notifications.DataAccess;

internal class NotificationCountQueryHandler : IQueryHandler<GetNotificationRequest, NotificationCountResult>
{
  INotificationRepository _notificationRepository;

    public NotificationCountQueryHandler(INotificationRepository notificationRepository)
    {
    _notificationRepository = notificationRepository;
  }
    public NotificationCountResult HandleQuery(GetNotificationRequest query)
  {
    return new NotificationCountResult
    {
      Result = _notificationRepository.GetSendNotificationsCount(query.NotificationType, query.LoginNames)
    };
  }
}

