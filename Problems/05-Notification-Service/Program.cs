using _05_Notification_Service.Decorator;
using _05_Notification_Service.Enums;
using _05_Notification_Service.Models;
using _05_Notification_Service.Service;
using _05_Notification_Service.Strategy.NotificationChannel;
using System;

Console.WriteLine("==================================================");
Console.WriteLine("       NOTIFICATION SERVICE DEMO SYSTEM           ");
Console.WriteLine("==================================================");
Console.WriteLine();

// 1. Get Singleton NotificationService Instance
Console.WriteLine("[INFO] Initializing NotificationService (Singleton)...");
var notificationService = NotificationService.GetInstance();

// 2. Setup Recipient Users
var userAlice = new User
{
    Id = 101,
    Name = "Alice Johnson",
    Email = "alice@example.com",
    PhoneNumber = "+1-555-0101"
};

var userBob = new User
{
    Id = 102,
    Name = "Bob Smith",
    Email = "bob@example.com",
    PhoneNumber = "+1-555-0202"
};

Console.WriteLine($"[INFO] Created user Alice ({userAlice.Email}, {userAlice.PhoneNumber})");
Console.WriteLine($"[INFO] Created user Bob ({userBob.Email}, {userBob.PhoneNumber})");
Console.WriteLine();

// 3. Send Notification via specific channel (Email)
Console.WriteLine("--- 1. Sending Email Notification ---");
var emailNotification = new Notification
{
    Recipient = userAlice,
    NotificationPriority = NotificationPriority.MEDIUM,
    NotificationContent = new NotificationContent { Body = "Your monthly statement is ready." },
    Channel = NotificationChannelEnum.EMAIL
};
notificationService.SendNotification(emailNotification);
Console.WriteLine();

// 4. Send Notification with Decorator Pattern (Urgent + Timestamp)
Console.WriteLine("--- 2. Sending Decorated High-Priority Notification (Urgent + Timestamp) ---");
var rawAlert = new Notification
{
    Recipient = userBob,
    NotificationPriority = NotificationPriority.HIGH,
    NotificationContent = new NotificationContent { Body = "Security alert: Suspicious login detected!" },
    Channel = NotificationChannelEnum.SMS
};

// Decorate with UrgentDecorator and TimeStampDecorator
Notification decoratedAlert = new TimeStampDecorator(new UrgentDecorator(rawAlert));
notificationService.SendNotification(decoratedAlert);
Console.WriteLine();

// 5. Send WhatsApp & In-App Notifications
Console.WriteLine("--- 3. Sending WhatsApp and In-App Notifications ---");
var whatsappNotification = new Notification
{
    Recipient = userAlice,
    NotificationPriority = NotificationPriority.LOW,
    NotificationContent = new NotificationContent { Body = "Your order #1234 has been shipped." },
    Channel = NotificationChannelEnum.WHATSAPP
};
notificationService.SendNotification(whatsappNotification);

var inAppNotification = new Notification
{
    Recipient = userBob,
    NotificationPriority = NotificationPriority.MEDIUM,
    NotificationContent = new NotificationContent { Body = "You have 3 unread messages." },
    Channel = NotificationChannelEnum.INAPP
};
notificationService.SendNotification(inAppNotification);
Console.WriteLine();

// 6. Dynamic Multi-Channel Notification (e.g. send to SMS and WhatsApp)
Console.WriteLine("--- 4. Sending Dynamically to Selected Channels (SMS + WhatsApp) ---");

// Approach A: Specify dynamic channels inside the notification itself
var multiChannelNotification1 = new Notification
{
    Recipient = userAlice,
    NotificationPriority = NotificationPriority.HIGH,
    NotificationContent = new NotificationContent { Body = "OTP: 987654. Do not share this with anyone." },
    Channels = new List<NotificationChannelEnum>
    {
        NotificationChannelEnum.SMS,
        NotificationChannelEnum.WHATSAPP
    }
};
Console.WriteLine("[INFO] Approach A: Channels configured on Notification model:");
notificationService.SendNotification(multiChannelNotification1);
Console.WriteLine();

// Approach B: Specify dynamic channels directly in the SendNotification call
var multiChannelNotification2 = new Notification
{
    Recipient = userBob,
    NotificationPriority = NotificationPriority.HIGH,
    NotificationContent = new NotificationContent { Body = "Transaction Alert: $150.00 debited from account." }
};
Console.WriteLine("[INFO] Approach B: Channels passed dynamically in SendNotification call:");
notificationService.SendNotification(
    multiChannelNotification2,
    NotificationChannelEnum.SMS,
    NotificationChannelEnum.WHATSAPP
);
Console.WriteLine();

// 7. Broadcast across all registered channels (when no channels specified)
Console.WriteLine("--- 5. Broadcasting Notification Across All Registered Channels ---");
var broadcastNotification = new Notification
{
    Recipient = userAlice,
    NotificationPriority = NotificationPriority.HIGH,
    NotificationContent = new NotificationContent { Body = "Critical system maintenance scheduled tonight at 12:00 AM UTC." }
};
notificationService.SendNotification(broadcastNotification);
Console.WriteLine();

// 8. Dynamic Channel Strategy Registration (Open-Closed Principle)
Console.WriteLine("--- 6. Dynamic Strategy Registration ---");
Console.WriteLine($"[INFO] Total registered channels: {notificationService.GetRegisteredChannels().Count}");
Console.WriteLine("[INFO] Removing SMS channel...");
notificationService.RemoveChannel(NotificationChannelEnum.SMS);
Console.WriteLine($"[INFO] Total registered channels now: {notificationService.GetRegisteredChannels().Count}");

Console.WriteLine("[INFO] Re-registering SMS channel...");
notificationService.RegisterChannel(new SmsNotificationChannel());
Console.WriteLine($"[INFO] Total registered channels now: {notificationService.GetRegisteredChannels().Count}");
Console.WriteLine();

Console.WriteLine("==================================================");
Console.WriteLine("       NOTIFICATION SERVICE DEMO COMPLETED        ");
Console.WriteLine("==================================================");