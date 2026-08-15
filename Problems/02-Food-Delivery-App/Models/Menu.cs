namespace FoodDeliveryApp.Models;

public class Menu
{
    private readonly List<MenuItem> _menuItems = new();

    public void AddItems(MenuItem menuItem)
    {
        _menuItems.Add(menuItem);
    }

    public IReadOnlyList<MenuItem> GetItems()
    {
        return _menuItems.AsReadOnly();
    }

    public void WatchMenu()
    {
        Console.WriteLine("--- Menu Items ---");
        foreach (var item in _menuItems)
        {
            Console.WriteLine($"Item: {item.GetName()} | Price: ₹{item.GetPrice()} | ID: {item.GetId()}");
        }
        Console.WriteLine("------------------");
    }
}
