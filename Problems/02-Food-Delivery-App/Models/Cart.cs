namespace FoodDeliveryApp.Models;

public class CartItem
{
    public MenuItem Item { get; }
    public int Quantity { get; private set; }

    public CartItem(MenuItem item, int quantity)
    {
        Item = item;
        Quantity = quantity;
    }

    public void AddQuantity(int quantity)
    {
        Quantity += quantity;
    }
}

public class Cart
{
    private readonly Dictionary<string, CartItem> _items = new();
    private Restaurant? _restaurant;

    public void SetRestaurant(Restaurant restaurant)
    {
        _restaurant = restaurant;
    }

    public void AddMenuItem(MenuItem item, Restaurant restaurant, int quantity = 1)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));

        if (_restaurant != null && _restaurant.GetId() != restaurant.GetId())
        {
            throw new InvalidOperationException(
                $"Cart already contains items from '{_restaurant.GetName()}'. Clear cart before adding items from '{restaurant.GetName()}'.");
        }

        _restaurant = restaurant;

        if (_items.TryGetValue(item.GetId(), out var existingItem))
        {
            existingItem.AddQuantity(quantity);
        }
        else
        {
            _items[item.GetId()] = new CartItem(item, quantity);
        }
    }

    public double GetTotalValue()
    {
        return _items.Values.Sum(ci => ci.Item.GetPrice() * ci.Quantity);
    }

    public Restaurant? GetRestaurant() => _restaurant;

    public IReadOnlyCollection<CartItem> GetItems() => _items.Values.ToList().AsReadOnly();

    public void ClearCart()
    {
        _items.Clear();
        _restaurant = null;
    }
}
