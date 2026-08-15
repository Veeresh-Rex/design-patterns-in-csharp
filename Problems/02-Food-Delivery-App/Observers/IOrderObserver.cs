using FoodDeliveryApp.Models;

namespace FoodDeliveryApp.Observers;

public interface IOrderObserver
{
    void Notify(Order order);
}
