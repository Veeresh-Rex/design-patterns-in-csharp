using FoodDeliveryApp.Models;

namespace FoodDeliveryApp.Strategies.Payment;

public class UpiPayment : IPaymentStrategy
{
    public bool Pay(double amount, User user)
    {
        Console.WriteLine($"Payment done for user: {user.GetName()} for amount: {amount}");
        return true;
    }
}
