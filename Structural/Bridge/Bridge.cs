namespace Csharp_design_patterns_lab.Structural.Bridge;

public interface ILabelPrinter
{
    void Print();
}

public class PdfPrinter : ILabelPrinter
{
    public void Print()
    {
        Console.WriteLine("PDF label");
    }
}

public class ZplPrinter : ILabelPrinter
{
    public void Print()
    {
        Console.WriteLine("ZPL label");
    }
}

public abstract class Shipment
{
    protected ILabelPrinter Printer;

    protected Shipment(ILabelPrinter printer)
    {
        Printer = printer;
    }
}

public class DomesticShipment : Shipment
{
    public DomesticShipment(ILabelPrinter printer)
    : base(printer)
    {
        
    }

    public void PrintLabel()
    {
        Printer.Print();
    }
}

public class InternationShipment : Shipment
{
    public InternationShipment(ILabelPrinter labelPrinter) : base(labelPrinter)
    {

    }

    public void PrintLabel()
    {
        Printer.Print();
    }
}

public static class Bridge
{
    public static void Invoke()
    {
        DomesticShipment domesticShipment = new DomesticShipment(new ZplPrinter());
        domesticShipment.PrintLabel();
    }
}
