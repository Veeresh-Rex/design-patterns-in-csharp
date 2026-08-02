namespace Csharp_design_patterns_lab.Creational.Builder;

public class Shipment()
{
    public string Carrier { get; set; }
    public decimal Weight { get; set; }
    public bool IsSignatureRequired { get; set; }
}

public class ShipmentBuilder
{
    private readonly Shipment _shipment = new Shipment();
    
    public ShipmentBuilder WithCarrier(string carrierName)
    {
        _shipment.Carrier = carrierName;
        return this;
    }

    public ShipmentBuilder WithWight(decimal weight)
    {
        _shipment.Weight = weight;
        return this;
    }
    public ShipmentBuilder WithSignatureRequired()
    {
        _shipment.IsSignatureRequired = true;
        return this;
    }

    public Shipment Build()
    {
        return _shipment;
    }

}


public static class Builder
{
    public static void Invoke()
    {
        ShipmentBuilder shipmentBuilder = new ShipmentBuilder();
        shipmentBuilder.WithCarrier("USPS").WithWight(10.97m).WithSignatureRequired();
        var shipment = shipmentBuilder.Build();

        // check weight
        Console.WriteLine(shipment.Weight);
    }
}
