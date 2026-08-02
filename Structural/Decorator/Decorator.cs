namespace Csharp_design_patterns_lab.Structural.Decorator;

public interface IMessageService
{
    void SendMessage(string message);
}

public class EmailService : IMessageService
{
    public void SendMessage(string message)
    {
        Console.WriteLine("Message Send " + message);
    }
}

// New wrapperr
public class LoggingDecorator : IMessageService
{
    private readonly IMessageService _messageService;

    public LoggingDecorator(IMessageService messageService)
    {
        _messageService = messageService;
    }
    public void SendMessage(string message)
    {
        Console.WriteLine("Logging");
        _messageService.SendMessage(message);
    }
}

public static class Decorator
{
    public static void Invoke()
    {
        IMessageService loggingDecorator = new LoggingDecorator(new EmailService());
        loggingDecorator.SendMessage("'Hey what's up?");
    }
}
