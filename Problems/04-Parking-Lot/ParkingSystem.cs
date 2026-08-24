using _04_Parking_Lot.Models;
using _04_Parking_Lot.Strategies.FeeCalculation;
using _04_Parking_Lot.Strategies.ParkingFindStrategy;

namespace _04_Parking_Lot;

public class ParkingSystem
{
    private static ParkingSystem? instance;
    private static readonly object lockObj = new object();
    private List<ParkingFloor> parkingFloors = new List<ParkingFloor>();
    private IParkingFindStrategy? parkingFindStrategy;
    private IFeeCalculationStrategy? feeCalculationStrategy;
    private List<ParkingTicket> activeParkings = new();

    private ParkingSystem() { }

    public static ParkingSystem GetInstance()
    {
        if (instance == null)
        {
            lock (lockObj)
            {
                instance ??= new ParkingSystem();
            }
        }
        return instance;
    }

    public void SetFeeCalculationStrategy(IFeeCalculationStrategy feeCalculationStrategy)
    {
        this.feeCalculationStrategy = feeCalculationStrategy;
    }

    public void SetParkingFindStrategy(IParkingFindStrategy parkingFindStrategy)
    {
        this.parkingFindStrategy = parkingFindStrategy;
    }

    public void AddParkingFloor(ParkingFloor parkingFloor)
    {
        parkingFloors.Add(parkingFloor);
    }

    public ParkingTicket? ParkVehical(Vehical vehical)
    {
        if (parkingFindStrategy == null || feeCalculationStrategy == null)
        {
            Console.WriteLine("[ERROR] Parking search strategy or Fee calculation strategy is not configured!");
            return null;
        }

        ParkingSpot? parkingSpot = parkingFindStrategy.FindParking(parkingFloors, vehical);
        if (parkingSpot == null)
        {
            Console.WriteLine($"[PARKING FULL] No available spot found for vehicle '{vehical.GetVehicalNumber()}' ({vehical.GetType().Name}, Size: {vehical.GetVehicalSize()}).");
            return null;
        }

        var parkingFee = feeCalculationStrategy.CalculateFee(vehical);
        ParkingTicket parkingTicket = new ParkingTicket(parkingSpot, vehical, DateTime.Now, parkingFee);
        parkingSpot.ParkVehical(vehical);
        activeParkings.Add(parkingTicket);

        Console.WriteLine($"[SUCCESS] Parked {vehical.GetType().Name} ({vehical.GetVehicalNumber()}) at Spot '{parkingSpot.GetSpotId()}' | Fee: ${parkingFee:F2}");
        return parkingTicket;
    }

    public void UnparkVehical(Vehical vehical)
    {
        var parkingTicket = activeParkings.FirstOrDefault(e => e.GetVehical().GetVehicalNumber() == vehical.GetVehicalNumber());
        if (parkingTicket == null)
        {
            Console.WriteLine($"[ERROR] Vehicle '{vehical.GetVehicalNumber()}' is not currently parked.");
            return;
        }

        parkingTicket.UpdateExitTime();
        parkingTicket.GetParkingSpot().UnparkVehical();
        activeParkings.Remove(parkingTicket);
        Console.WriteLine($"[UNPARKED] Vehicle '{vehical.GetVehicalNumber()}' unparked from Spot '{parkingTicket.GetParkingSpot().GetSpotId()}'.");
    }
}
