using _04_Parking_Lot.Enums;
using _04_Parking_Lot.Models;

namespace _04_Parking_Lot.Strategies.FeeCalculation;

public class FlatRateFeeCalculationStrategy : IFeeCalculationStrategy
{
    public decimal CalculateFee(Vehical vehical)
    {
        return vehical.GetVehicalSize() switch
        {
            VehicalSize.Small => 10.00m,
            VehicalSize.Medium => 20.00m,
            VehicalSize.Large => 50.00m,
            _ => 15.00m
        };
    }
}
