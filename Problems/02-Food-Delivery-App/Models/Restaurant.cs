using FoodDeliveryApp.Observers;

namespace FoodDeliveryApp.Models;

public class Restaurant : IOrderObserver
{
    private readonly string _id;
    private string _name;
    private readonly string _address;
    private readonly Menu _menu;

    public Restaurant(string id, string name, string address)
        : this(id, name, address, new Menu())
    {
    }

    public Restaurant(string id, string name, string address, Menu menu)
    {
        _id = id;
        _name = name;
        _address = address;
        _menu = menu ?? new Menu();
    }

    public string GetId() => _id;
    public string GetName() => _name;
    public string GetAddress() => _address;

    public void UpdateName(string newName)
    {
        _name = newName;
    }

    public Menu GetMenu() => _menu;

    public void AddItemInMenu(MenuItem menuItem)
    {
        _menu.AddItems(menuItem);
    }

    public void Notify(Order order)
    {
        Console.WriteLine($"Restaurant Notification - {GetName()}: Order {order.GetId()} status changed to {order.GetStatus()}");
    }
}
