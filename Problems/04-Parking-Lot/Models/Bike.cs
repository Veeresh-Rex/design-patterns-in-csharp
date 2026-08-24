using _04_Parking_Lot.Enums;

namespace _04_Parking_Lot.Models;

public class Bike : Vehical
{
    public Bike(string number) : base(VehicalSize.Small, number)
    {

    }
}
