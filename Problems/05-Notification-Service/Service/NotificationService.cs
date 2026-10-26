using _05_Notification_Service.Decorator;
using _05_Notification_Service.Enums;
using _05_Notification_Service.Models;
using _05_Notification_Service.Queue;
using _05_Notification_Service.Strategy.NotificationChannel;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace _05_Notification_Service.Service;

public class NotificationService
{
    private static readonly Lazy<NotificationService> instance =
        new(() => new NotificationService());

    private readonly ConcurrentDictionary<NotificationChannelEnum, INotificationChannel> _channelStrategies = new();
    private readonly PriorityNotificationQueue _queue = new();

    private NotificationService()
    {
        RegisterChannel(new EmailNotificationChannel());
        RegisterChannel(new SmsNotificationChannel());
        RegisterChannel(new WhatsAppNotificationChannel());
        RegisterChannel(new InAppNotificationChannel());
    }

    public static NotificationService GetInstance() => instance.Value;

    public PriorityNotificationQueue Queue => _queue;

    public void RegisterChannel(INotificationChannel channel)
    {
        if (channel == null) throw new ArgumentNullException(nameof(channel));
        _channelStrategies[channel.NotificationChannel] = channel;
    }

    public void RemoveChannel(NotificationChannelEnum channelType)
    {
        _channelStrategies.TryRemove(channelType, out _);
    }

    public IReadOnlyCollection<INotificationChannel> GetRegisteredChannels() => _channelStrategies.Values.ToList();

    public void Enqueue(Notification notification)
    {
        _queue.Enqueue(notification);
    }

    public async Task<bool> ProcessNextQueuedAsync(CancellationToken ct = default)
    {
        var notification = await _queue.DequeueAsync(ct);
        return await SendNotificationAsync(notification);
    }

    public async Task<int> ProcessAllQueuedAsync(CancellationToken ct = default)
    {
        int processedCount = 0;
        while (_queue.TryDequeue(out var notification) && notification != null)
        {
            await SendNotificationAsync(notification);
            processedCount++;
        }
        return processedCount;
    }

    public async Task<bool> SendNotificationAsync(Notification notification, params NotificationChannelEnum[] requestedChannels)
    {
        if (notification == null) throw new ArgumentNullException(nameof(notification));

        Notification prepared = notification;
        while (prepared is NotificationDecorator decorator)
        {
            prepared = decorator.GetNotification();
        }

        prepared.NotificationContent ??= new NotificationContent();

        var retryPolicy = GetRetryPolicyForPriority(prepared.Priority);

        var channelsToSend = requestedChannels.Length > 0
            ? requestedChannels.Distinct()
            : (prepared.Channels.Count > 0 ? prepared.Channels.Distinct() : _channelStrategies.Keys);

        bool allSucceeded = true;
        foreach (var channelType in channelsToSend)
        {
            if (_channelStrategies.TryGetValue(channelType, out var strategy))
            {
                bool sent = await retryPolicy.ExecuteAsync(() => strategy.SendNotification(prepared));
                if (!sent) allSucceeded = false;
            }
            else
            {
                Console.WriteLine($"[ERROR] Channel '{channelType}' is not registered.");
                allSucceeded = false;
            }
        }

        return allSucceeded;
    }

    public bool SendNotification(Notification notification, params NotificationChannelEnum[] requestedChannels)
    {
        return SendNotificationAsync(notification, requestedChannels).GetAwaiter().GetResult();
    }

    private static RetryService GetRetryPolicyForPriority(NotificationPriority priority) => priority switch
    {
        NotificationPriority.HIGH => new RetryService(retryMaxCount: 3),
        NotificationPriority.MEDIUM => new RetryService(retryMaxCount: 2),
        NotificationPriority.LOW => new RetryService(retryMaxCount: 1),
        _ => new RetryService(retryMaxCount: 1)
    };
}
