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

Console.WriteLine("[INFO] Initializing NotificationService (Singleton)...");
var notificationService = NotificationService.GetInstance();

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

Console.WriteLine("--- 1. Sending Email Notification ---");
var emailNotification = new Notification
{
    Recipient = userAlice,
    Priority = NotificationPriority.MEDIUM,
    NotificationContent = new NotificationContent { Body = "Your monthly statement is ready." },
    Channels = { NotificationChannelEnum.EMAIL }
};
notificationService.SendNotification(emailNotification);
Console.WriteLine();

Console.WriteLine("--- 2. Sending Decorated High-Priority Notification (Urgent + Timestamp) ---");
var rawAlert = new Notification
{
    Recipient = userBob,
    Priority = NotificationPriority.HIGH,
    NotificationContent = new NotificationContent { Body = "Security alert: Suspicious login detected!" },
    Channels = { NotificationChannelEnum.SMS }
};

Notification decoratedAlert = new TimeStampDecorator(new UrgentDecorator(rawAlert));
notificationService.SendNotification(decoratedAlert);
Console.WriteLine();

Console.WriteLine("--- 3. Sending WhatsApp and In-App Notifications ---");
var whatsappNotification = new Notification
{
    Recipient = userAlice,
    Priority = NotificationPriority.LOW,
    NotificationContent = new NotificationContent { Body = "Your order #1234 has been shipped." },
    Channels = { NotificationChannelEnum.WHATSAPP }
};
notificationService.SendNotification(whatsappNotification);

var inAppNotification = new Notification
{
    Recipient = userBob,
    Priority = NotificationPriority.MEDIUM,
    NotificationContent = new NotificationContent { Body = "You have 3 unread messages." },
    Channels = { NotificationChannelEnum.INAPP }
};
notificationService.SendNotification(inAppNotification);
Console.WriteLine();

Console.WriteLine("--- 4. Sending Dynamically to Selected Channels (SMS + WhatsApp) ---");

var multiChannelNotification1 = new Notification
{
    Recipient = userAlice,
    Priority = NotificationPriority.HIGH,
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

var multiChannelNotification2 = new Notification
{
    Recipient = userBob,
    Priority = NotificationPriority.HIGH,
    NotificationContent = new NotificationContent { Body = "Transaction Alert: $150.00 debited from account." }
};
Console.WriteLine("[INFO] Approach B: Channels passed dynamically in SendNotification call:");
notificationService.SendNotification(
    multiChannelNotification2,
    NotificationChannelEnum.SMS,
    NotificationChannelEnum.WHATSAPP
);
Console.WriteLine();

Console.WriteLine("--- 5. Broadcasting Notification Across All Registered Channels ---");
var broadcastNotification = new Notification
{
    Recipient = userAlice,
    Priority = NotificationPriority.HIGH,
    NotificationContent = new NotificationContent { Body = "Critical system maintenance scheduled tonight at 12:00 AM UTC." }
};
notificationService.SendNotification(broadcastNotification);
Console.WriteLine();

Console.WriteLine("--- 6. Dynamic Strategy Registration ---");
Console.WriteLine($"[INFO] Total registered channels: {notificationService.GetRegisteredChannels().Count}");
Console.WriteLine("[INFO] Removing SMS channel...");
notificationService.RemoveChannel(NotificationChannelEnum.SMS);
Console.WriteLine($"[INFO] Total registered channels now: {notificationService.GetRegisteredChannels().Count}");

Console.WriteLine("[INFO] Re-registering SMS channel...");
notificationService.RegisterChannel(new SmsNotificationChannel());
Console.WriteLine($"[INFO] Total registered channels now: {notificationService.GetRegisteredChannels().Count}");
Console.WriteLine();

Console.WriteLine("--- 7. Priority Notification Queue (Higher Priority First, FIFO Tie-Breaking) ---");
Console.WriteLine("[INFO] Enqueuing notifications in mixed priority order:");

var low1 = new Notification
{
    Recipient = userAlice,
    Priority = NotificationPriority.LOW,
    NotificationContent = new NotificationContent { Body = "[1] Promo: 20% off on your next purchase!" },
    Channels = { NotificationChannelEnum.EMAIL }
};
Console.WriteLine("  -> Enqueued: [LOW] Promo 20% off");
notificationService.Enqueue(low1);

var med1 = new Notification
{
    Recipient = userBob,
    Priority = NotificationPriority.MEDIUM,
    NotificationContent = new NotificationContent { Body = "[2] Order #5544 is being packed." },
    Channels = { NotificationChannelEnum.INAPP }
};
Console.WriteLine("  -> Enqueued: [MEDIUM] Order #5544 update");
notificationService.Enqueue(med1);

var high1 = new Notification
{
    Recipient = userAlice,
    Priority = NotificationPriority.HIGH,
    NotificationContent = new NotificationContent { Body = "[3] SECURITY: New login from unknown device!" },
    Channels = { NotificationChannelEnum.SMS }
};
Console.WriteLine("  -> Enqueued: [HIGH - 1st] Security Alert");
notificationService.Enqueue(high1);

var high2 = new Notification
{
    Recipient = userBob,
    Priority = NotificationPriority.HIGH,
    NotificationContent = new NotificationContent { Body = "[4] OTP: 443322 for password reset." },
    Channels = { NotificationChannelEnum.WHATSAPP }
};
Console.WriteLine("  -> Enqueued: [HIGH - 2nd] Password Reset OTP");
notificationService.Enqueue(high2);

Console.WriteLine();
Console.WriteLine($"[INFO] Queue contains {notificationService.Queue.Count} items. Processing queue in priority order...");

await notificationService.ProcessAllQueuedAsync();
Console.WriteLine();

Console.WriteLine("==================================================");
Console.WriteLine("       NOTIFICATION SERVICE DEMO COMPLETED        ");
Console.WriteLine("==================================================");