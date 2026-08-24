using _04_Parking_Lot.Models;

namespace _04_Parking_Lot.Strategies.ParkingFindStrategy;

public class FirstAvailableSpotStrategy : IParkingFindStrategy
{
    public ParkingSpot? FindParking(List<ParkingFloor> parkingFloors, Vehical vehical)
    {
        foreach (var floor in parkingFloors)
        {
            foreach (var spot in floor.GetFreeParking())
            {
                if (!spot.IsOccupied() && spot.CanFitVehical(vehical.GetVehicalSize()))
                {
                    return spot;
                }
            }
        }
        return null;
    }
}
