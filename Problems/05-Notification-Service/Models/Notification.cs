using _05_Notification_Service.Enums;
using System;
using System.Collections.Generic;

namespace _05_Notification_Service.Models;

public class Notification
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public User Recipient { get; set; } = new();
    public NotificationPriority Priority { get; set; } = NotificationPriority.LOW;
    public NotificationContent NotificationContent { get; set; } = new();
    public List<NotificationChannelEnum> Channels { get; set; } = new();
}
