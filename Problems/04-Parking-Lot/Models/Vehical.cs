using _04_Parking_Lot.Enums;

namespace _04_Parking_Lot.Models;

public abstract class Vehical
{
    private readonly VehicalSize vehicalSize;
    private readonly string vehicalNumber;

    protected Vehical(VehicalSize vehicalSize, string vehicalNumber)
    {
        this.vehicalSize = vehicalSize;
        this.vehicalNumber = vehicalNumber;
    }

    public VehicalSize GetVehicalSize()
    {
        return this.vehicalSize;
    }

    public string GetVehicalNumber()
    {
        return this.vehicalNumber;
    }
}
