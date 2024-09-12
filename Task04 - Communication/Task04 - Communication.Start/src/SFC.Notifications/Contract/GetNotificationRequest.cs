using SFC.Infrastructure.Interfaces;
using SFC.SharedKernel;

public class GetNotificationRequest : IRequest<NotificationCountResult>
{
    public string NotificationType { get; set; }
    public LoginName[] LoginNames { get; set; }
}

