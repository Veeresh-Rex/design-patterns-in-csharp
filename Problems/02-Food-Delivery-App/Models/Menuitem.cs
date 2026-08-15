namespace FoodDeliveryApp.Models;

public class MenuItem
{
    private readonly string _id;
    private readonly string _name;
    private readonly double _price;

    public MenuItem(string id, string name, double price)
    {
        _id = id;
        _name = name;
        _price = price;
    }

    public string GetId() => _id;
    public string GetName() => _name;
    public double GetPrice() => _price;
}