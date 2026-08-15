namespace FoodDeliveryApp.Models;

public class Menu
{
    private readonly List<Menuitem> menuitems = new List<Menuitem>();
    public void AddItems(Menuitem menuitem)
    {
        menuitems.Add(menuitem);
    }

    public List<Menuitem> GetItems()
    {
        return menuitems;
    }

    public void WatchMenu()
    {
        foreach (var item in menuitems)
        {
            Console.WriteLine($"{item.GetName()}: Price: {item.GetPrice()}");
        }
    }
}
