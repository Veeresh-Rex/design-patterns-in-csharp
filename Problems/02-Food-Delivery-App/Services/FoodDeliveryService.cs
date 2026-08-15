using FoodDeliveryApp.Models;
using FoodDeliveryApp.Strategies.Payment;
using FoodDeliveryApp.Strategies.Search;

namespace FoodDeliveryApp.Services;

public class FoodDeliveryService
{
    private static FoodDeliveryService instance;
    private readonly List<User> users = new();
    private readonly List<Restaurant> restaurants = new();
    private readonly List<Order> orders = new();
    private IPaymentStrategy paymentStrategy;
    private IRestaurantSearchStreatgy restaurantSearch;

    private FoodDeliveryService() { }

    public static FoodDeliveryService GetInstance()
    {
        if(instance is null)
        {
            instance = new FoodDeliveryService();
        }

        return instance;
    }

    public void SetRestoSearchStratgy(IRestaurantSearchStreatgy restaurantSearchService)
    {
        this.restaurantSearch = restaurantSearchService;
    }

    public void SetPaymentStretgy(IPaymentStrategy paymentStrategy)
    {
        this.paymentStrategy= paymentStrategy;
    }

    public User CreateUser(string userName)
    {
        Guid id = Guid.NewGuid();

        User newuser = new User(id.ToString(), userName);

        users.Add(newuser);

        return newuser;
    }

    public Restaurant CreateResto(string name, string address)
    {
        Guid id = Guid.NewGuid();
        Restaurant newResto = new Restaurant(id.ToString(),name, address, new Menu());

        restaurants.Add(newResto);
        return newResto;
    }

    public Order CreateOrder(string restoid, string userId, Cart cart) {
        Guid id = Guid.NewGuid();
        User user = users.FirstOrDefault(e => e.GetId() == userId);
        Order newOrder = new Order(id.ToString(), cart, user, restaurants.FirstOrDefault(e => e.GetId() == restoid));

        newOrder.Checkout(paymentStrategy);
        newOrder.UpdateStatus(Enums.OrderStatus.RECIEVED);
        orders.Add(newOrder);

        return newOrder;
    }

    public List<Restaurant> SearchRestaurants(string keyword)
    {
        return restaurantSearch.SearchResto(keyword, restaurants);
    }

    public void MarkOrderOutForDelivery(string orderId) {
        Order order = orders.FirstOrDefault(e => e.GetId() == orderId);
        order.UpdateStatus(Enums.OrderStatus.OUTFORDELIVERY);
    }

    public void MarkorderDelivered(string orderId)
    {
        Order order = orders.FirstOrDefault(e => e.GetId() == orderId);
        order.UpdateStatus(Enums.OrderStatus.DELIVERED);
    }
}
