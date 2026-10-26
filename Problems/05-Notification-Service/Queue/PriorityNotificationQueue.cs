using _05_Notification_Service.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace _05_Notification_Service.Queue;

public class PriorityNotificationQueue
{
    private readonly PriorityQueue<Notification, (int, long)> _queue = new();
    private readonly SemaphoreSlim _signal = new(0);
    private long _sequence;

    public int Count
    {
        get
        {
            lock (_queue) return _queue.Count;
        }
    }

    public void Enqueue(Notification n)
    {
        if (n == null) throw new ArgumentNullException(nameof(n));
        lock (_queue)
        {
            _queue.Enqueue(n, (-(int)n.Priority, _sequence++));
        }
        _signal.Release();
    }

    public async Task<Notification> DequeueAsync(CancellationToken ct = default)
    {
        await _signal.WaitAsync(ct);
        lock (_queue)
        {
            return _queue.Dequeue();
        }
    }

    public bool TryDequeue(out Notification? notification)
    {
        lock (_queue)
        {
            if (_queue.Count > 0 && _signal.Wait(0))
            {
                notification = _queue.Dequeue();
                return true;
            }
            notification = null;
            return false;
        }
    }
}
