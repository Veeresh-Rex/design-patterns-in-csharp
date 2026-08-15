using FoodDeliveryApp.Models;
using FoodDeliveryApp.Services;
using FoodDeliveryApp.Strategies.Payment;
using FoodDeliveryApp.Strategies.Search;

FoodDeliveryService service = FoodDeliveryService.GetInstance();
service.SetRestoSearchStratgy(new AddressbasedSearch());
service.SetPaymentStretgy(new UpiPayment());

var restro1 = service.CreateResto("Dev's Restro", "Noida sector 15");
var restro2 = service.CreateResto("Naagpal ji ke chole bhature", "New Delhi, 110011");

var user = service.CreateUser("veer");

restro1.AddItemInMenu(new Menuitem("001", "Cheese bread", 200));
restro1.AddItemInMenu(new Menuitem("002", "Burgur", 150));
restro1.AddItemInMenu(new Menuitem("003", "Coffee", 70));


restro2.AddItemInMenu(new Menuitem("001", "Chole bhature", 200));
restro2.AddItemInMenu(new Menuitem("002", "Chaach", 150));
restro2.AddItemInMenu(new Menuitem("003", "Rajma chawal", 70));


var restorants = service.SearchRestaurants("delhi");

if (restorants.Count == 0)
{
    Console.WriteLine("No restaurrent found");
    throw new Exception("No restaurrent found");
}
// user select 1st restro
var userSeletedrestro = restorants.First();

var menu = userSeletedrestro.GetMenu();
menu.WatchMenu();

// Suppose user select 1st option

var selectItem = menu.GetItems().FirstOrDefault();
var cart = user.AddItemsInCart(selectItem);
var order = service.CreateOrder(userSeletedrestro.GetId(), user.GetId(), cart);

service.MarkOrderOutForDelivery(order.GetId());
service.MarkorderDelivered(order.GetId());
