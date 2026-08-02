using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_design_patterns_lab.Structural.Facade;

public class Computer
{
    public void GetElectricShock()
    {
        Console.Write("Ouch!");
    }

    public void MakeSound()
    {
        Console.Write("Beep beep!");
    }

    public void ShowLoadingScreen()
    {
        Console.Write("Loading..");
    }

    public void Bam()
    {
        Console.Write("Ready to be used!");
    }

    public void CloseEverything()
    {
        Console.Write("Bup bup bup buzzzz!");
    }

    public void Sooth()
    {
        Console.Write("Zzzzz");
    }

    public void PullCurrent()
    {
        Console.Write("Haaah!");
    }
}

class ComputerFacade
{
    private readonly Computer mComputer;

    public ComputerFacade(Computer computer)
    {
        this.mComputer = computer ?? throw new ArgumentNullException("computer", "computer cannot be null");
    }

    public void TurnOn()
    {
        mComputer.GetElectricShock();
        mComputer.MakeSound();
        mComputer.ShowLoadingScreen();
        mComputer.Bam();
    }

    public void TurnOff()
    {
        mComputer.CloseEverything();
        mComputer.PullCurrent();
        mComputer.Sooth();
    }
}

public static class Facade
{
    public static void Invoke()
    {
        Computer computer = new Computer();
        ComputerFacade computerFacade = new ComputerFacade(computer);
        computerFacade.TurnOn();
        Console.WriteLine();
        computerFacade.TurnOff();
    }
}
