using FoodDeliveryApp.Models;

namespace FoodDeliveryApp.Strategies.Search;

public interface IRestaurantSearchStreatgy
{
    List<Restaurant> SearchResto(string keyword, List<Restaurant> restaurants);
}
