using System;

namespace Csharp_design_patterns_lab.DesignPatterns.Behavioral.Strategy;

public interface IPaymentStrategy
{
    void Pay(decimal amount);
}

public class CreditCardPayment : IPaymentStrategy
{
    private readonly string _cardNumber;

    public CreditCardPayment(string cardNumber)
    {
        _cardNumber = cardNumber;
    }

    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paid ${amount} using Credit Card ending in {_cardNumber[^4..]}");
    }
}

public class PayPalPayment : IPaymentStrategy
{
    private readonly string _email;

    public PayPalPayment(string email)
    {
        _email = email;
    }

    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paid ${amount} using PayPal account {_email}");
    }
}

public class CryptoPayment : IPaymentStrategy
{
    private readonly string _walletAddress;

    public CryptoPayment(string walletAddress)
    {
        _walletAddress = walletAddress;
    }

    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paid ${amount} using Crypto Wallet {_walletAddress}");
    }
}

public class ShoppingCart
{
    private IPaymentStrategy? _paymentStrategy;

    public void SetPaymentStrategy(IPaymentStrategy strategy)
    {
        _paymentStrategy = strategy;
    }

    public void Checkout(decimal amount)
    {
        if (_paymentStrategy == null)
        {
            Console.WriteLine("Please select a payment method before checking out.");
            return;
        }

        _paymentStrategy.Pay(amount);
    }
}

public static class StrategyDemo
{
    public static void Invoke()
    {
        var cart = new ShoppingCart();

        cart.SetPaymentStrategy(new CreditCardPayment("1234567812345678"));
        cart.Checkout(150.00m);

        cart.SetPaymentStrategy(new PayPalPayment("user@example.com"));
        cart.Checkout(75.50m);

        cart.SetPaymentStrategy(new CryptoPayment("0xABC123DEF456"));
        cart.Checkout(300.25m);

        Console.WriteLine();
    }
}
