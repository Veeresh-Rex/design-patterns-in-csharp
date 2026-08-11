using System;

namespace Csharp_design_patterns_lab.DesignPatterns.Creational.AbstractFactory;

public interface ILabelGenerator
{
    void GenerateLabel();
}

public interface IRateCalculator
{
    void CalculateRate();
}

public class USPSLabelGenerator : ILabelGenerator
{
    public void GenerateLabel()
    {
        Console.WriteLine("Generating USPS shipping label.");
    }
}

public class FedExLabelGenerator : ILabelGenerator
{
    public void GenerateLabel()
    {
        Console.WriteLine("Generating FedEx shipping label.");
    }
}

public class USPSRating : IRateCalculator
{
    public void CalculateRate()
    {
        Console.WriteLine("Calculating USPS shipping rate.");
    }
}

public class FedExRating : IRateCalculator
{
    public void CalculateRate()
    {
        Console.WriteLine("Calculating FedEx shipping rate.");
    }
}

public interface ICarrierFactory
{
    ILabelGenerator CreateLabelGenerator();
    IRateCalculator CreateRateCalculator();
}

public class UspsFactory : ICarrierFactory
{
    public ILabelGenerator CreateLabelGenerator() => new USPSLabelGenerator();
    public IRateCalculator CreateRateCalculator() => new USPSRating();
}

public class FedExFactory : ICarrierFactory
{
    public ILabelGenerator CreateLabelGenerator() => new FedExLabelGenerator();
    public IRateCalculator CreateRateCalculator() => new FedExRating();
}

public static class AbstractFactoryDemo
{
    public static void Invoke()
    {
        Console.WriteLine("Abstract Factory Pattern:");

        Console.WriteLine("Working with USPS factory:");
        ICarrierFactory uspsFactory = new UspsFactory();
        var uspsRate = uspsFactory.CreateRateCalculator();
        var uspsLabel = uspsFactory.CreateLabelGenerator();
        uspsRate.CalculateRate();
        uspsLabel.GenerateLabel();

        Console.WriteLine();

        Console.WriteLine("Working with FedEx factory:");
        ICarrierFactory fedExFactory = new FedExFactory();
        var fedExRate = fedExFactory.CreateRateCalculator();
        var fedExLabel = fedExFactory.CreateLabelGenerator();
        fedExRate.CalculateRate();
        fedExLabel.GenerateLabel();

        Console.WriteLine();
    }
}
