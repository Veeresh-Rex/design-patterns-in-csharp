using FoodDeliveryApp.Enums;
using FoodDeliveryApp.Observers;
using FoodDeliveryApp.Strategies.Payment;

namespace FoodDeliveryApp.Models;

public class Order
{
    private readonly string _id;
    private OrderStatus _status;
    private readonly Cart _cart;
    private readonly double _totalAmount;
    private readonly List<IOrderObserver> _observers = new();
    private readonly User _user;
    private readonly Restaurant _restaurant;

    public Order(string id, Cart cart, User user, Restaurant restaurant)
    {
        _id = id;
        _cart = cart;
        _user = user;
        _restaurant = restaurant;
        _totalAmount = cart.GetTotalValue();

        if (user != null) AddObserver(user);
        if (restaurant != null) AddObserver(restaurant);
    }

    public string GetId() => _id;
    public OrderStatus GetStatus() => _status;
    public double GetTotalAmount() => _totalAmount;
    public User GetUser() => _user;
    public Restaurant GetRestaurant() => _restaurant;

    public void AddObserver(IOrderObserver observer)
    {
        if (observer != null && !_observers.Contains(observer))
        {
            _observers.Add(observer);
        }
    }

    public void RemoveObserver(IOrderObserver observer)
    {
        if (observer != null)
        {
            _observers.Remove(observer);
        }
    }

    public void NotifyObservers()
    {
        foreach (IOrderObserver observer in _observers.ToList())
        {
            observer.Notify(this);
        }
    }

    public void UpdateStatus(OrderStatus orderStatus)
    {
        _status = orderStatus;
        NotifyObservers();
    }

    public bool Checkout(IPaymentStrategy paymentStrategy)
    {
        if (paymentStrategy == null)
            throw new ArgumentNullException(nameof(paymentStrategy), "Payment strategy cannot be null.");

        return paymentStrategy.Pay(_totalAmount, _user);
    }
}
