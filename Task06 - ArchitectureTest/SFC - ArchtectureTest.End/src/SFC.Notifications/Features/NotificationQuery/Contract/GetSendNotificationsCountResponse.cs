using SFC.Infrastructure.Interfaces;
using System.Collections.Generic;

namespace SFC.Notifications.Features.NotificationQuery.Contract
{
    internal class GetSendNotificationsCountResponse : IResponse
    {
        public IEnumerable<NotificationsCountResult> Result { get; set; }
    }
}