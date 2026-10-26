using _05_Notification_Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05_Notification_Service.Decorator;

public abstract class NotificationDecorator : Notification
{
    protected readonly Notification notification;
    protected NotificationDecorator(Notification notification)
    {
        this.notification = notification ?? throw new ArgumentNullException(nameof(notification));
        Id = notification.Id;
        Recipient = notification.Recipient;
        NotificationPriority = notification.NotificationPriority;
        NotificationContent = notification.NotificationContent;
        Channels = new List<Enums.NotificationChannelEnum>(notification.Channels);
    }

    public abstract Notification GetNotification();
}
