using FoodDeliveryApp.Observers;

namespace FoodDeliveryApp.Models;

public class Restaurant : IOrderObserver
{
    private readonly string _id;
    private string _name;
    private readonly string _address;
    private readonly Menu _menu;
    public Restaurant(string id, string name, string address)
    {
        _id = id;
        _name = name;
        _address = address;
    }

    public Restaurant(string id, string name, string address, Menu menu)
    {
        _id = id;
        _name = name;
        _address = address;
        _menu = menu;
    }

    public string GetId()
    {
        return _id;
    }

    public string GetName()
    {

        return _name;
    }

    public string GetAddress()
    {
        return _address;
    }

    public void UpdateName(string newName)
    {
        _name = newName.ToLower();
    }

    public Menu GetMenu()
    {
        return _menu;
    }

    public void AddItemInMenu(Menuitem menuitem)
    {
        _menu.AddItems(menuitem);
    }

    public void Notify(Order order)
    {
        Console.WriteLine($"Notification triggered for Restorant: Order status has been changed to {order.GetStatus()}");
    }
}
