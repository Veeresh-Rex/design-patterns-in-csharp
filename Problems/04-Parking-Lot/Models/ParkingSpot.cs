using _04_Parking_Lot.Enums;

namespace _04_Parking_Lot.Models;

public class ParkingSpot
{
    private readonly VehicalSize vehicalSize;
    private bool isOccupied = false;
    private readonly string spotId;
    private Vehical? parkedVehical = null;

    public ParkingSpot(string id, VehicalSize size)
    {
        this.spotId = id;
        this.vehicalSize = size;
    }

    public bool CanFitVehical(VehicalSize vehicalSize)
    {
        return this.vehicalSize == vehicalSize;
    }

    public string GetSpotId()
    {
        return spotId;
    }

    public bool IsOccupied()
    {
        return isOccupied;
    }

    public void ParkVehical(Vehical vehical)
    {
        parkedVehical = vehical;
        isOccupied = true;
    }

    public void UnparkVehical()
    {
        parkedVehical = null;
        isOccupied = false;
    }

    public Vehical? GetParkedVehical()
    {
        return parkedVehical;
    }
}
