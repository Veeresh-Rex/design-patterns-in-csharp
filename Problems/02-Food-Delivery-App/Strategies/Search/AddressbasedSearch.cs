using FoodDeliveryApp.Models;

namespace FoodDeliveryApp.Strategies.Search;

public class AddressbasedSearch : IRestaurantSearchStreatgy
{
    public List<Restaurant> SearchResto(string keyword, List<Restaurant> restaurants)
    {
        return restaurants.Where(e => e.GetAddress().Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}
