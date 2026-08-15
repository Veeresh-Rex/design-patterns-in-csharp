using FoodDeliveryApp.Models;

namespace FoodDeliveryApp.Strategies.Payment;

public interface IPaymentStrategy
{
    bool Pay(double amount, User user);
}
