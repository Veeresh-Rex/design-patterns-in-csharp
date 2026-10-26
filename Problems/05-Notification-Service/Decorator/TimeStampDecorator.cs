using _05_Notification_Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05_Notification_Service.Decorator;

public class TimeStampDecorator : NotificationDecorator
{
    public TimeStampDecorator(Notification notification) : base(notification)
    {
    }

    public override Notification GetNotification()
    {
        notification.NotificationContent.Body += $" Time: {DateTime.UtcNow}";
        return notification;
    }
}
