using _05_Notification_Service.Models;

namespace _05_Notification_Service.Decorator;

public class UrgentDecorator : NotificationDecorator
{
    public UrgentDecorator(Notification notification) : base(notification)
    {
    }

    public override Notification GetNotification()
    {
        if (notification.Priority == Enums.NotificationPriority.HIGH)
        {
            notification.NotificationContent.Body += " This is urgent";
        }
        return notification;
    }
}
