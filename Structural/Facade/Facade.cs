using System;

namespace Csharp_design_patterns_lab.Structural.Facade;

public class Computer
{
    public void GetElectricShock()
    {
        Console.WriteLine("Ouch! Static electricity shock.");
    }

    public void MakeSound()
    {
        Console.WriteLine("Beep beep! POST passed.");
    }

    public void ShowLoadingScreen()
    {
        Console.WriteLine("Loading operating system...");
    }

    public void Bam()
    {
        Console.WriteLine("Ready to be used!");
    }

    public void CloseEverything()
    {
        Console.WriteLine("Closing running applications...");
    }

    public void Sooth()
    {
        Console.WriteLine("Spinning down hard drives (Zzzzz)...");
    }

    public void PullCurrent()
    {
        Console.WriteLine("Cutting power. Haaah!");
    }
}

public class ComputerFacade
{
    private readonly Computer _computer;

    public ComputerFacade(Computer computer)
    {
        _computer = computer ?? throw new ArgumentNullException(nameof(computer));
    }

    public void TurnOn()
    {
        Console.WriteLine("Booting system...");
        _computer.GetElectricShock();
        _computer.MakeSound();
        _computer.ShowLoadingScreen();
        _computer.Bam();
    }

    public void TurnOff()
    {
        Console.WriteLine("Shutting down system...");
        _computer.CloseEverything();
        _computer.PullCurrent();
        _computer.Sooth();
    }
}

public static class FacadeDemo
{
    public static void Invoke()
    {
        Console.WriteLine("Facade Pattern:");

        Computer computer = new Computer();
        ComputerFacade computerFacade = new ComputerFacade(computer);
        
        computerFacade.TurnOn();
        Console.WriteLine();
        
        computerFacade.TurnOff();
        Console.WriteLine();
    }
}
