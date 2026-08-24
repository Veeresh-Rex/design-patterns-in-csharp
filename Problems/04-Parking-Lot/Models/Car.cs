using _04_Parking_Lot.Enums;

namespace _04_Parking_Lot.Models;

public class Car : Vehical
{
    public Car(string number) : base(VehicalSize.Medium, number)
    {

    }
}
