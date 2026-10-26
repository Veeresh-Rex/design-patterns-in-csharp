using _05_Notification_Service.Enums;

namespace _05_Notification_Service.Models;

public class Notification
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public User Recipient { get; set; } = new();
    public NotificationPriority NotificationPriority { get; set; } = NotificationPriority.LOW;
    public NotificationContent NotificationContent { get; set; } = new();

    public List<NotificationChannelEnum> Channels { get; set; } = new();

    // Convenience property for single channel backward compatibility
    public NotificationChannelEnum? Channel
    {
        get => Channels.Count > 0 ? Channels[0] : null;
        set
        {
            Channels.Clear();
            if (value.HasValue)
            {
                Channels.Add(value.Value);
            }
        }
    }

    public Notification AddChannel(NotificationChannelEnum channel)
    {
        if (!Channels.Contains(channel))
        {
            Channels.Add(channel);
        }
        return this;
    }
}
