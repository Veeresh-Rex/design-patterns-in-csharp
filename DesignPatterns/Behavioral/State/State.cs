using System;

namespace Csharp_design_patterns_lab.DesignPatterns.Behavioral.State;

public interface IVendingMachineState
{
    void InsertCoin(VendingMachine machine);
    void EjectCoin(VendingMachine machine);
    void DispenseItem(VendingMachine machine);
}

public class NoCoinState : IVendingMachineState
{
    public void InsertCoin(VendingMachine machine)
    {
        Console.WriteLine("Coin inserted.");
        machine.SetState(machine.HasCoinState);
    }

    public void EjectCoin(VendingMachine machine)
    {
        Console.WriteLine("No coin to eject.");
    }

    public void DispenseItem(VendingMachine machine)
    {
        Console.WriteLine("Insert coin first.");
    }
}

public class HasCoinState : IVendingMachineState
{
    public void InsertCoin(VendingMachine machine)
    {
        Console.WriteLine("Coin already inserted.");
    }

    public void EjectCoin(VendingMachine machine)
    {
        Console.WriteLine("Coin returned.");
        machine.SetState(machine.NoCoinState);
    }

    public void DispenseItem(VendingMachine machine)
    {
        Console.WriteLine("Dispensing product...");
        machine.SetState(machine.NoCoinState);
    }
}

public class VendingMachine
{
    public IVendingMachineState NoCoinState { get; }
    public IVendingMachineState HasCoinState { get; }

    private IVendingMachineState _currentState;

    public VendingMachine()
    {
        NoCoinState = new NoCoinState();
        HasCoinState = new HasCoinState();
        _currentState = NoCoinState;
    }

    public void SetState(IVendingMachineState state) => _currentState = state;

    public void InsertCoin() => _currentState.InsertCoin(this);
    public void EjectCoin() => _currentState.EjectCoin(this);
    public void DispenseItem() => _currentState.DispenseItem(this);
}

public static class StateDemo
{
    public static void Invoke()
    {
        var machine = new VendingMachine();

        machine.DispenseItem();
        machine.InsertCoin();
        machine.DispenseItem();

        Console.WriteLine();
    }
}
