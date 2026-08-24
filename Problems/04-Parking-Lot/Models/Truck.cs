using _04_Parking_Lot.Enums;

namespace _04_Parking_Lot.Models;

public class Truck : Vehical
{
    public Truck(string number) : base(VehicalSize.Large, number)
    {

    }
}
