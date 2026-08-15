using FoodDeliveryApp.Observers;

namespace FoodDeliveryApp.Models;

public class User : IOrderObserver
{
    private readonly string _id;
    private readonly string _name;
    private readonly Cart _cart;

    public User(string id, string name)
    {
        _id = id;
        _name = name;
        _cart = new Cart();
    }

    public string GetName() => _name;
    public string GetId() => _id;
    public Cart GetCart() => _cart;

    public Cart AddItemsInCart(MenuItem menuItem, Restaurant restaurant, int quantity = 1)
    {
        _cart.AddMenuItem(menuItem, restaurant, quantity);
        return _cart;
    }

    public void Notify(Order order)
    {
        Console.WriteLine($"User Notification - {GetName()}: Order {order.GetId()} status changed to {order.GetStatus()}");
    }
}
