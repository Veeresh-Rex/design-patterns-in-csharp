namespace FoodDeliveryApp.Models;

public class Cart
{
    private readonly List<Menuitem> menuitems = new List<Menuitem>();
    private Restaurant _restaurant;
    private double totalValue = 0;

    public Cart()
    {
    }

    public void SetRestaurant(Restaurant restaurant)
    {
        _restaurant = restaurant;
    }

    public void AddMenuItem(Menuitem menuitem)
    {
        totalValue += menuitem.GetPrice();
        menuitems.Add(menuitem);
    }

    public double GetTotalValue()
    {
        return totalValue;
    }

    public Restaurant GetRestaurant()
    {
        return _restaurant;
    }
}
