using SFC.Infrastructure.Interfaces;
using SFC.SharedKernel;

namespace SFC.Notifications.Features.NotificationQuery.Contract
{
    public class NotificationsCountResult : IResponse
    {
        public LoginName LoginName { get; set; }
        public int Count { get; set; }
    }
}