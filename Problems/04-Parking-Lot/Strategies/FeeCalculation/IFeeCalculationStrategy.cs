using _04_Parking_Lot.Models;

namespace _04_Parking_Lot.Strategies.FeeCalculation;

public interface IFeeCalculationStrategy
{
    decimal CalculateFee(Vehical vehical);
}
