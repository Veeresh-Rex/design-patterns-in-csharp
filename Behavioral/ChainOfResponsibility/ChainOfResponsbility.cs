namespace Csharp_design_patterns_lab.Behavioral.ChainOfResponsibility;

public class HttpRequest
{
    public string? ApiKey { get; set; }
    public string? User { get; set; }
    public int RequestCountPerDay { get; set; }
}

public interface IRequestHandler
{
    public void SetHandler(IRequestHandler requestHandler);
    public void Handle(HttpRequest request);
}

public class AuthenticationHandler : IRequestHandler
{
    private IRequestHandler? requestHandler;

    public void SetHandler(IRequestHandler requestHandler)
    {
        this.requestHandler = requestHandler;
    }

    public void Handle(HttpRequest request)
    {
        if (!string.IsNullOrEmpty(request.ApiKey) && request.ApiKey == "12345")
        {
            request.User = "Testing User";
            Console.WriteLine("Authenticated successfully");

            requestHandler?.Handle(request);
        }
        else
        {
            Console.WriteLine("APIKey is wrong");
        }
    }
}

public class AuthoriztionHandler : IRequestHandler
{
    private IRequestHandler? requestHandler;

    public void SetHandler(IRequestHandler requestHandler)
    {
        this.requestHandler = requestHandler;
    }

    public void Handle(HttpRequest request)
    {
        if (!string.IsNullOrEmpty(request.User))
        {
            Console.WriteLine("User is Authrozied");

            requestHandler?.Handle(request);
        }
        else
        {
            Console.WriteLine("User is not authroized");
        }
    }
}

public class RateLimitHandler : IRequestHandler
{
    private IRequestHandler? requestHandler;
    private const int MaxRequestCount = 5;

    public void SetHandler(IRequestHandler requestHandler)
    {
        this.requestHandler = requestHandler;
    }

    public void Handle(HttpRequest request)
    {
        if (request.RequestCountPerDay < MaxRequestCount && requestHandler is not null)
        {
            requestHandler.Handle(request);
        }
        else
        {
            Console.WriteLine("User API call limit reach");
        }
        request.RequestCountPerDay++;
    }
}

public class BusinessLogicHandler : IRequestHandler
{
    private IRequestHandler? requestHandler;

    public void SetHandler(IRequestHandler requestHandler)
    {
        this.requestHandler = requestHandler;
    }

    public void Handle(HttpRequest request)
    {
        Console.WriteLine("Executing business logic");
    }
}

public static class ChainOfResponsbility
{
    public static void Invoke()
    {
        IRequestHandler authRequestHandler = new AuthenticationHandler();
        IRequestHandler authrizeRequestHandler = new AuthoriztionHandler();
        IRequestHandler rateLimitHandler = new RateLimitHandler();
        IRequestHandler businessLogicHandler = new BusinessLogicHandler();

        authRequestHandler.SetHandler(authrizeRequestHandler);
        authrizeRequestHandler.SetHandler(rateLimitHandler);
        rateLimitHandler.SetHandler(businessLogicHandler);

        HttpRequest httpRequest1 = new HttpRequest();
        httpRequest1.ApiKey = "12345";
        authRequestHandler.Handle(httpRequest1);
        authRequestHandler.Handle(httpRequest1);
        authRequestHandler.Handle(httpRequest1);
        authRequestHandler.Handle(httpRequest1);
        authRequestHandler.Handle(httpRequest1);
        authRequestHandler.Handle(httpRequest1);
    }
}


