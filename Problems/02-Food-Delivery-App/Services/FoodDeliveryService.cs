using FoodDeliveryApp.Enums;
using FoodDeliveryApp.Models;
using FoodDeliveryApp.Strategies.Payment;
using FoodDeliveryApp.Strategies.Search;

namespace FoodDeliveryApp.Services;

public class FoodDeliveryService
{
    private static readonly Lazy<FoodDeliveryService> _instance = new(() => new FoodDeliveryService());

    private readonly List<User> _users = new();
    private readonly List<Restaurant> _restaurants = new();
    private readonly List<Order> _orders = new();

    private IPaymentStrategy _paymentStrategy = new UpiPayment(); // Default strategy fallback
    private IRestaurantSearchStrategy _restaurantSearch = new AddressBasedSearch(); // Default strategy fallback

    private FoodDeliveryService() { }

    public static FoodDeliveryService GetInstance() => _instance.Value;

    public void SetRestaurantSearchStrategy(IRestaurantSearchStrategy restaurantSearchService)
    {
        _restaurantSearch = restaurantSearchService ?? throw new ArgumentNullException(nameof(restaurantSearchService));
    }

    public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy ?? throw new ArgumentNullException(nameof(paymentStrategy));
    }

    public User CreateUser(string userName)
    {
        if (string.IsNullOrWhiteSpace(userName))
            throw new ArgumentException("User name cannot be empty.", nameof(userName));

        Guid id = Guid.NewGuid();
        User newUser = new User(id.ToString(), userName);
        _users.Add(newUser);
        return newUser;
    }

    public Restaurant CreateRestaurant(string name, string address)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Restaurant name cannot be empty.", nameof(name));

        Guid id = Guid.NewGuid();
        Restaurant newResto = new Restaurant(id.ToString(), name, address, new Menu());
        _restaurants.Add(newResto);
        return newResto;
    }

    public List<Restaurant> SearchRestaurants(string keyword)
    {
        if (_restaurantSearch == null)
            throw new InvalidOperationException("Restaurant search strategy is not set.");

        return _restaurantSearch.SearchResto(keyword, _restaurants);
    }

    public Order CreateOrder(string restoId, string userId, Cart cart)
    {
        User user = _users.FirstOrDefault(e => e.GetId() == userId)
                    ?? throw new KeyNotFoundException($"User with ID '{userId}' not found.");

        Restaurant resto = _restaurants.FirstOrDefault(e => e.GetId() == restoId)
                           ?? throw new KeyNotFoundException($"Restaurant with ID '{restoId}' not found.");

        if (cart == null || cart.GetItems().Count == 0)
            throw new InvalidOperationException("Cannot create an order with an empty cart.");

        Guid orderId = Guid.NewGuid();
        Order newOrder = new Order(orderId.ToString(), cart, user, resto);

        bool paymentSuccess = newOrder.Checkout(_paymentStrategy);
        if (!paymentSuccess)
        {
            throw new InvalidOperationException("Payment failed. Order creation aborted.");
        }

        newOrder.UpdateStatus(OrderStatus.RECEIVED);
        _orders.Add(newOrder);

        return newOrder;
    }

    public void MarkOrderOutForDelivery(string orderId)
    {
        Order order = _orders.FirstOrDefault(e => e.GetId() == orderId)
                      ?? throw new KeyNotFoundException($"Order with ID '{orderId}' not found.");

        order.UpdateStatus(OrderStatus.OUT_FOR_DELIVERY);
    }

    public void MarkOrderDelivered(string orderId)
    {
        Order order = _orders.FirstOrDefault(e => e.GetId() == orderId)
                      ?? throw new KeyNotFoundException($"Order with ID '{orderId}' not found.");

        order.UpdateStatus(OrderStatus.DELIVERED);
    }

    public Order? GetOrderById(string orderId)
    {
        return _orders.FirstOrDefault(e => e.GetId() == orderId);
    }
}
