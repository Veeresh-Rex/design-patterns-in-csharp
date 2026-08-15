using FoodDeliveryApp.Models;

namespace FoodDeliveryApp.Strategies.Search;

public interface IRestaurantSearchStrategy
{
    List<Restaurant> SearchResto(string keyword, List<Restaurant> restaurants);
}
