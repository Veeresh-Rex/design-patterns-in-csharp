using _04_Parking_Lot.Models;

namespace _04_Parking_Lot.Strategies.ParkingFindStrategy;

public interface IParkingFindStrategy
{
    ParkingSpot? FindParking(List<ParkingFloor> parkingFloors, Vehical vehical);
}
