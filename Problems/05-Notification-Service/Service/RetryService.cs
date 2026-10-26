namespace _05_Notification_Service.Service;

public class RetryService
{
    private readonly int _retryMaxCount;
    public RetryService(int retryMaxCount)
    {
        _retryMaxCount = retryMaxCount;
    }

    public async Task<bool> ExecuteAsync(Func<bool> operation)
    {
        for (int attempt = 1; ; attempt++)
        {
            bool result = operation();

            if (result)
            {
                return true;
            }

            if (attempt == _retryMaxCount)
            {
                return false;
            }

            var exponentialMs = Math.Min(60_000, 1_000 * Math.Pow(2, attempt - 1));

            var jitterMs = Random.Shared.Next(0, 500);

            await Task.Delay(
                TimeSpan.FromMilliseconds(exponentialMs + jitterMs));
        }
    }
}
