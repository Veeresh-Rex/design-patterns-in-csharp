using FoodDeliveryApp.Enums;
using FoodDeliveryApp.Observers;
using FoodDeliveryApp.Strategies.Payment;

namespace FoodDeliveryApp.Models;

public class Order
{
    private readonly string _id;
    private OrderStatus _status;
    private readonly Cart _cart;
    private readonly List<IOrderObserver> observers = new List<IOrderObserver>();
    private readonly User _user;
    private readonly Restaurant _restaurant;

    public Order(string id, Cart cart, User user, Restaurant restaurant)
    {
        _id = id;
        _cart = cart;
        _user = user;
        AddObserver(user);
        AddObserver(restaurant);
    }
    
    public string GetId()
    {
        return _id;
    }

    public void AddObserver(IOrderObserver observer)
    {
        observers.Add(observer);
    }

    public OrderStatus GetStatus() { return _status; }

    public void NotifyObservers()
    {
        foreach (IOrderObserver observer in observers)
        {
            observer.Notify(this);
        }
    }

    public void UpdateStatus(OrderStatus orderStatus)
    {
        _status = orderStatus;
        NotifyObservers();
    }

    public void Checkout(IPaymentStrategy paymentStrategy)
    {
        paymentStrategy.Pay(_cart.GetTotalValue(), _user);
    }
}
