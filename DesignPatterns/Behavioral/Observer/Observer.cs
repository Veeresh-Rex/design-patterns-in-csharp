using System;
using System.Collections.Generic;

namespace Csharp_design_patterns_lab.DesignPatterns.Behavioral.Observer;

public interface IObserver
{
    void Update(string stockSymbol, decimal price);
}

public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}

public class StockTicker : ISubject
{
    private readonly List<IObserver> _observers = new();
    public string Symbol { get; }
    private decimal _price;

    public StockTicker(string symbol, decimal initialPrice)
    {
        Symbol = symbol;
        _price = initialPrice;
    }

    public decimal Price
    {
        get => _price;
        set
        {
            if (_price != value)
            {
                _price = value;
                Notify();
            }
        }
    }

    public void Attach(IObserver observer) => _observers.Add(observer);
    public void Detach(IObserver observer) => _observers.Remove(observer);

    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update(Symbol, _price);
        }
    }
}

public class Investor : IObserver
{
    public string Name { get; }

    public Investor(string name)
    {
        Name = name;
    }

    public void Update(string stockSymbol, decimal price)
    {
        Console.WriteLine($"[Notification for {Name}] {stockSymbol} price changed to ${price}");
    }
}

public static class ObserverDemo
{
    public static void Invoke()
    {
        Console.WriteLine("--- Observer Pattern ---");
        var msft = new StockTicker("MSFT", 400.00m);

        var alice = new Investor("Alice");
        var bob = new Investor("Bob");

        msft.Attach(alice);
        msft.Attach(bob);

        msft.Price = 412.50m;
        msft.Price = 418.00m;

        msft.Detach(bob);
        msft.Price = 425.00m;

        Console.WriteLine();
    }
}
