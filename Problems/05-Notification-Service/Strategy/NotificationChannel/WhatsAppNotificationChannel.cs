using _05_Notification_Service.Enums;
using _05_Notification_Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05_Notification_Service.Strategy.NotificationChannel;

public class WhatsAppNotificationChannel : INotificationChannel
{
    public NotificationChannelEnum NotificationChannel => NotificationChannelEnum.WHATSAPP;

    public bool SendNotification(Notification notification)
    {
        Console.WriteLine($"[WHATSAPP] Sent to '{notification.Recipient.PhoneNumber}' | Priority: {notification.Priority} | Body: {notification.NotificationContent.Body}");
        return true;
    }
}
