
namespace _04_Parking_Lot.Models;

public class ParkingTicket
{
    private ParkingSpot parkingSpot;
    private Vehical vehical;
    private DateTime entryTime;
    private DateTime? exitTime;
    private decimal fee;

    public ParkingTicket(ParkingSpot parkingSpot, Vehical vehical, DateTime entryTime, decimal fee)
    {
        this.parkingSpot = parkingSpot;
        this.vehical = vehical;
        this.entryTime = entryTime;
        this.fee = fee;
    }

    public void UpdateExitTime()
    {
        exitTime = DateTime.Now;
    }

    public ParkingSpot GetParkingSpot()
    {
        return parkingSpot;
    }

    public Vehical GetVehical()
    {
        return vehical;
    }

    public DateTime GetEntryTime()
    {
        return entryTime;
    }

    public DateTime? GetExitTime()
    {
        return exitTime;
    }

    public decimal GetFee()
    {
        return fee;
    }
}
