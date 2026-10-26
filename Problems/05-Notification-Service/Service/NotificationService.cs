using _05_Notification_Service.Decorator;
using _05_Notification_Service.Enums;
using _05_Notification_Service.Models;
using _05_Notification_Service.Strategy.NotificationChannel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _05_Notification_Service.Service;

public class NotificationService
{
    private static readonly Lazy<NotificationService> instance =
        new Lazy<NotificationService>(() => new NotificationService());

    private RetryService retryPolicy;
    private readonly List<INotificationChannel> notificationStrategies;

    private NotificationService()
    {
        retryPolicy = new RetryService(3);
        notificationStrategies = new List<INotificationChannel>
        {
            new EmailNotificationChannel(),
            new SmsNotificationChannel(),
            new WhatsAppNotificationChannel(),
            new InAppNotificationChannel()
        };
    }

    public static NotificationService GetInstance()
    {
        return instance.Value;
    }

    public void SetRetryPolicy(RetryService policy)
    {
        retryPolicy = policy ?? throw new ArgumentNullException(nameof(policy));
    }

    public void RegisterChannel(INotificationChannel channel)
    {
        if (channel == null) throw new ArgumentNullException(nameof(channel));
        notificationStrategies.RemoveAll(c => c.NotificationChannel == channel.NotificationChannel);
        notificationStrategies.Add(channel);
    }

    public void RemoveChannel(NotificationChannelEnum channelType)
    {
        notificationStrategies.RemoveAll(c => c.NotificationChannel == channelType);
    }

    public IReadOnlyList<INotificationChannel> GetRegisteredChannels()
    {
        return notificationStrategies.AsReadOnly();
    }

    public async Task<bool> SendNotificationAsync(Notification notification, params NotificationChannelEnum[] channels)
    {
        return await SendNotificationAsync(notification, (IEnumerable<NotificationChannelEnum>)channels);
    }

    public async Task<bool> SendNotificationAsync(Notification notification, IEnumerable<NotificationChannelEnum>? channels = null)
    {
        if (notification == null)
        {
            throw new ArgumentNullException(nameof(notification));
        }

        // 1. Unwrap decorators if present
        Notification preparedNotification = notification;
        while (preparedNotification is NotificationDecorator decorator)
        {
            preparedNotification = decorator.GetNotification();
        }

        preparedNotification.NotificationContent ??= new NotificationContent();

        // 2. Determine target channels dynamically:
        //    Priority 1: Explicit channels passed into method call
        //    Priority 2: Channels defined in notification.Channels
        //    Priority 3: Broadcast to all registered channels if none specified
        List<NotificationChannelEnum> targetChannels;

        if (channels != null && channels.Any())
        {
            targetChannels = channels.Distinct().ToList();
        }
        else if (preparedNotification.Channels != null && preparedNotification.Channels.Count > 0)
        {
            targetChannels = preparedNotification.Channels.Distinct().ToList();
        }
        else
        {
            targetChannels = notificationStrategies.Select(s => s.NotificationChannel).ToList();
        }

        if (targetChannels.Count == 0)
        {
            Console.WriteLine("[ERROR] No notification channels available to send.");
            return false;
        }

        bool allSucceeded = true;
        foreach (var channelType in targetChannels)
        {
            var strategy = notificationStrategies.FirstOrDefault(s => s.NotificationChannel == channelType);
            if (strategy == null)
            {
                Console.WriteLine($"[ERROR] No notification strategy registered for channel '{channelType}'.");
                allSucceeded = false;
                continue;
            }

            bool success = await retryPolicy.ExecuteAsync(() => strategy.SendNotification(preparedNotification));
            if (!success)
            {
                allSucceeded = false;
            }
        }

        return allSucceeded;
    }

    public bool SendNotification(Notification notification, params NotificationChannelEnum[] channels)
    {
        return SendNotificationAsync(notification, channels).GetAwaiter().GetResult();
    }

    public bool SendNotification(Notification notification, IEnumerable<NotificationChannelEnum>? channels = null)
    {
        return SendNotificationAsync(notification, channels).GetAwaiter().GetResult();
    }
}
