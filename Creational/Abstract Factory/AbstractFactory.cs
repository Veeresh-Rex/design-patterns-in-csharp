namespace Csharp_design_patterns_lab.Creational.Abstract_Factory;

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
        Console.WriteLine("Generating USPS label");
    }
}

public class FedExLabelGenerator : ILabelGenerator
{
    public void GenerateLabel()
    {
        Console.WriteLine("Generating FedEx label");
    }
}

public class USPSRating : IRateCalculator
{
    public void CalculateRate()
    {
        Console.WriteLine("Calculating USPS rate");
    }
}

public class FedExRating : IRateCalculator
{
    public void CalculateRate()
    {
        Console.WriteLine("Calculating fedex rate");
    }
}

public interface ICarrierFactory
{
    ILabelGenerator CreateLabelGenerator();
    IRateCalculator CreateRateCalculator();
}

public class UspsFactory : ICarrierFactory
{
    public ILabelGenerator CreateLabelGenerator()
    {
        return new USPSLabelGenerator();
    }

    public IRateCalculator CreateRateCalculator()
    {
        return new USPSRating();
    }
}

public class FedExFactory : ICarrierFactory
{
    public ILabelGenerator CreateLabelGenerator()
    {
        return new FedExLabelGenerator();
    }

    public IRateCalculator CreateRateCalculator()
    {
        return new FedExRating();
    }
}

public static class AbstractFactory
{
    public static void Invoke()
    {
        ICarrierFactory carrierFactory = new UspsFactory();
        var ratingObj = carrierFactory.CreateRateCalculator();
        ratingObj.CalculateRate();

        var lableObj = carrierFactory.CreateLabelGenerator();
        lableObj.GenerateLabel();
    }
}
