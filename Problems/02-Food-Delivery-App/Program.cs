using FoodDeliveryApp.Models;
using FoodDeliveryApp.Services;
using FoodDeliveryApp.Strategies.Payment;
using FoodDeliveryApp.Strategies.Search;

Console.WriteLine("=======================================");
Console.WriteLine("   Food Delivery App Demonstration     ");
Console.WriteLine("=======================================\n");

FoodDeliveryService service = FoodDeliveryService.GetInstance();
service.SetRestaurantSearchStrategy(new AddressBasedSearch());
service.SetPaymentStrategy(new UpiPayment());

// 1. Create Restaurants & Add Menu Items
var resto1 = service.CreateRestaurant("Dev's Restro", "Noida sector 15");
var resto2 = service.CreateRestaurant("Naagpal Ji Ke Chole Bhature", "New Delhi, 110011");

resto1.AddItemInMenu(new MenuItem("M101", "Cheese Bread", 200));
resto1.AddItemInMenu(new MenuItem("M102", "Burger", 150));
resto1.AddItemInMenu(new MenuItem("M103", "Coffee", 70));

resto2.AddItemInMenu(new MenuItem("M201", "Chole Bhature", 200));
resto2.AddItemInMenu(new MenuItem("M202", "Chaach", 50));
resto2.AddItemInMenu(new MenuItem("M203", "Rajma Chawal", 180));

// 2. Create User
var user = service.CreateUser("Veeresh");
Console.WriteLine($"Created User: {user.GetName()} (ID: {user.GetId()})\n");

// 3. Search Restaurants by Keyword
string searchLocation = "Delhi";
Console.WriteLine($"Searching for restaurants with address containing '{searchLocation}'...");
var searchResults = service.SearchRestaurants(searchLocation);

if (searchResults.Count == 0)
{
    Console.WriteLine("No restaurants found.");
    return;
}

var selectedResto = searchResults.First();
Console.WriteLine($"Selected Restaurant: {selectedResto.GetName()} ({selectedResto.GetAddress()})\n");

// 4. View Menu
var menu = selectedResto.GetMenu();
menu.WatchMenu();
Console.WriteLine();

// 5. User Adds Items to Cart 
var menuItems = menu.GetItems();
var item1 = menuItems[0]; // Chole Bhature
var item2 = menuItems[1]; // Chaach

Console.WriteLine($"Adding 2x {item1.GetName()} and 1x {item2.GetName()} to cart...");
user.AddItemsInCart(item1, selectedResto, quantity: 2);
user.AddItemsInCart(item2, selectedResto, quantity: 1);

var cart = user.GetCart();
Console.WriteLine($"Cart Total Value: ₹{cart.GetTotalValue()}");

// Test multi-restaurant restriction:
try
{
    var foreignItem = new MenuItem("M999", "Foreign Item", 100);
    cart.AddMenuItem(foreignItem, resto1, 1);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"{ex.Message}");
}

// 6. Create Order & Process Status Workflow
Console.WriteLine("Placing Order...");
var order = service.CreateOrder(selectedResto.GetId(), user.GetId(), cart);
Console.WriteLine($"Order placed successfully! Order ID: {order.GetId()}, Total: ₹{order.GetTotalAmount()}\n");

Console.WriteLine("Updating Order Workflow Statuses...");
service.MarkOrderOutForDelivery(order.GetId());
service.MarkOrderDelivered(order.GetId());

Console.WriteLine("=======================================");
Console.WriteLine("   Demonstration Completed Successfully ");
Console.WriteLine("=======================================");
