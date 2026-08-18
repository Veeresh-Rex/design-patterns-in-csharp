namespace TicTacToe.Observer;

public class NotificationObserver : IObserver
{
    public void Update(string message)
    {
        Console.WriteLine($"Trigger notification: {message}");
    }
}
