using _05_Notification_Service.Enums;
using _05_Notification_Service.Models;

namespace _05_Notification_Service.Strategy.NotificationChannel;

public interface INotificationChannel
{
    NotificationChannelEnum NotificationChannel { get; }
    bool SendNotification(Notification notification);
}
