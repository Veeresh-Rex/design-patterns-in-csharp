using FoodDeliveryApp.Models;

namespace FoodDeliveryApp.Strategies.Search;

public class AddressBasedSearch : IRestaurantSearchStrategy
{
    public List<Restaurant> SearchResto(string keyword, List<Restaurant> restaurants)
    {
        if (string.IsNullOrWhiteSpace(keyword))
            return new List<Restaurant>();

        return restaurants
            .Where(e => e.GetAddress().Contains(keyword, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}
