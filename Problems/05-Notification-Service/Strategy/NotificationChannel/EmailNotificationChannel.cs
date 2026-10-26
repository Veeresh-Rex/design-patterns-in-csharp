using _05_Notification_Service.Enums;
using _05_Notification_Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05_Notification_Service.Strategy.NotificationChannel;

public class EmailNotificationChannel : INotificationChannel
{
    public NotificationChannelEnum NotificationChannel => NotificationChannelEnum.EMAIL;

    public bool SendNotification(Notification notification)
    {
        Console.WriteLine($"[EMAIL] Sent to '{notification.Recipient.Email}' | Priority: {notification.Priority} | Body: {notification.NotificationContent.Body}");
        return true;
    }
}
