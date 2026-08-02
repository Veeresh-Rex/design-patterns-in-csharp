using System;

namespace Csharp_design_patterns_lab.Structural.Bridge;

public interface ILabelPrinter
{
    void Print();
}

public class PdfPrinter : ILabelPrinter
{
    public void Print()
    {
        Console.WriteLine("PDF Label Printed.");
    }
}

public class ZplPrinter : ILabelPrinter
{
    public void Print()
    {
        Console.WriteLine("ZPL Label Printed.");
    }
}

public abstract class Shipment
{
    protected readonly ILabelPrinter Printer;

    protected Shipment(ILabelPrinter printer)
    {
        Printer = printer ?? throw new ArgumentNullException(nameof(printer));
    }

    public virtual void PrintLabel()
    {
        Printer.Print();
    }
}

public class DomesticShipment : Shipment
{
    public DomesticShipment(ILabelPrinter printer) : base(printer)
    {
    }

    public override void PrintLabel()
    {
        Console.Write("Domestic Shipment - ");
        base.PrintLabel();
    }
}

public class InternationalShipment : Shipment
{
    public InternationalShipment(ILabelPrinter printer) : base(printer)
    {
    }

    public override void PrintLabel()
    {
        Console.Write("International Shipment - ");
        base.PrintLabel();
    }
}

public static class BridgeDemo
{
    public static void Invoke()
    {
        Console.WriteLine("Bridge Pattern:");

        Console.WriteLine("Printing domestic label via ZPL printer:");
        Shipment domesticZpl = new DomesticShipment(new ZplPrinter());
        domesticZpl.PrintLabel();

        Console.WriteLine("\nPrinting international label via PDF printer:");
        Shipment internationalPdf = new InternationalShipment(new PdfPrinter());
        internationalPdf.PrintLabel();

        Console.WriteLine();
    }
}
