namespace FoodDeliveryApp.Models;

public class Menuitem
{
    private readonly string _id;
    private readonly string _name;
    private readonly double _price;
    public Menuitem(string id, string name, double price)
    {
        _id = id;
        _name = name;
        _price = price;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetId()
    {
        return _id;
    }

    public double GetPrice()
    {

        return _price;
    }
}