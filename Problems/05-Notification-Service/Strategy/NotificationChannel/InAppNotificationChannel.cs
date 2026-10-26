using _05_Notification_Service.Enums;
using _05_Notification_Service.Models;

namespace _05_Notification_Service.Strategy.NotificationChannel;

public class InAppNotificationChannel : INotificationChannel
{
    public NotificationChannelEnum NotificationChannel => NotificationChannelEnum.INAPP;

    public bool SendNotification(Notification notification)
    {
        Console.WriteLine($"[IN-APP] Sent to User '{notification.Recipient.Name}' (ID: {notification.Recipient.Id}) | Priority: {notification.NotificationPriority} | Body: {notification.NotificationContent.Body}");
        return true;
    }
}
