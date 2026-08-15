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

    public string GetName()
    {
        return _name;
    }

    public string GetId()
    {
        return _id;
    }

    public Cart GetCart()
    {
        return _cart;
    }

    public Cart AddItemsInCart(Menuitem menuitem)
    {
        _cart.AddMenuItem(menuitem);
        return _cart;
    }

    public void Notify(Order order)
    {
        Console.WriteLine($"Notification triggered for user {GetName()}: Order status has been changed to {order.GetStatus()}");
    }
}
