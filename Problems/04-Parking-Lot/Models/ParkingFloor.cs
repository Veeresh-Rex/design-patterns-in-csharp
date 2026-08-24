namespace _04_Parking_Lot.Models;

public class ParkingFloor
{
    private readonly List<ParkingSpot> parkingSpots = new List<ParkingSpot>();
    private readonly string floorNumber;
    
    public ParkingFloor(string floorNo)
    {
        floorNumber = floorNo;
    }

    public string GetFloorNumber()
    {
        return floorNumber;
    }

    public void AddParkingSpot(ParkingSpot parkingSpot)
    {
        parkingSpots.Add(parkingSpot);
    }

    public List<ParkingSpot> GetFreeParking()
    {
        return parkingSpots.Where(e => !e.IsOccupied()).ToList();
    }
}
