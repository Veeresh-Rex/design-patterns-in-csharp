using _05_Notification_Service.Enums;
using _05_Notification_Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05_Notification_Service.Strategy.NotificationChannel;

public class SmsNotificationChannel : INotificationChannel
{
    public NotificationChannelEnum NotificationChannel => NotificationChannelEnum.SMS;

    public bool SendNotification(Notification notification)
    {
        Console.WriteLine($"[SMS] Sent to '{notification.Recipient.PhoneNumber}' | Priority: {notification.Priority} | Body: {notification.NotificationContent.Body}");
        return true;
    }
}
