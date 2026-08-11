using System;

namespace Csharp_design_patterns_lab.DesignPatterns.Creational.Builder;

public class Shipment
{
    public string Carrier { get; set; } = string.Empty;
    public decimal Weight { get; set; }
    public bool IsSignatureRequired { get; set; }

    public override string ToString()
    {
        return $"Shipment [Carrier={Carrier}, Weight={Weight} lbs, SignatureRequired={IsSignatureRequired}]";
    }
}

public class ShipmentBuilder
{
    private string _carrier = string.Empty;
    private decimal _weight;
    private bool _isSignatureRequired;

    public ShipmentBuilder WithCarrier(string carrierName)
    {
        _carrier = carrierName ?? throw new ArgumentNullException(nameof(carrierName));
        return this;
    }

    public ShipmentBuilder WithWeight(decimal weight)
    {
        _weight = weight;
        return this;
    }

    public ShipmentBuilder WithSignatureRequired()
    {
        _isSignatureRequired = true;
        return this;
    }

    public Shipment Build()
    {
        var shipment = new Shipment
        {
            Carrier = _carrier,
            Weight = _weight,
            IsSignatureRequired = _isSignatureRequired
        };

        Reset();
        return shipment;
    }

    private void Reset()
    {
        _carrier = string.Empty;
        _weight = 0;
        _isSignatureRequired = false;
    }
}

public static class BuilderDemo
{
    public static void Invoke()
    {
        Console.WriteLine("Builder Pattern:");

        ShipmentBuilder shipmentBuilder = new ShipmentBuilder();
        
        Shipment shipment1 = shipmentBuilder
            .WithCarrier("USPS")
            .WithWeight(10.97m)
            .WithSignatureRequired()
            .Build();

        Console.WriteLine($"Shipment 1 built: {shipment1}");

        Shipment shipment2 = shipmentBuilder
            .WithCarrier("FedEx")
            .WithWeight(2.5m)
            .Build();

        Console.WriteLine($"Shipment 2 built: {shipment2}");
        Console.WriteLine();
    }
}
