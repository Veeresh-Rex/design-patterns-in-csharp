using Csharp_design_patterns_lab.DesignPatterns.Behavioral.ChainOfResponsibility;
using Csharp_design_patterns_lab.DesignPatterns.Behavioral.Command;
using Csharp_design_patterns_lab.DesignPatterns.Behavioral.Memento;
using Csharp_design_patterns_lab.DesignPatterns.Behavioral.Observer;
using Csharp_design_patterns_lab.DesignPatterns.Behavioral.State;
using Csharp_design_patterns_lab.DesignPatterns.Behavioral.Strategy;
using Csharp_design_patterns_lab.DesignPatterns.Creational.AbstractFactory;
using Csharp_design_patterns_lab.DesignPatterns.Creational.Builder;
using Csharp_design_patterns_lab.DesignPatterns.Creational.Factory;
using Csharp_design_patterns_lab.DesignPatterns.Creational.Prototype;
using Csharp_design_patterns_lab.DesignPatterns.Creational.SimpleFactory;
using Csharp_design_patterns_lab.DesignPatterns.Creational.Singleton;
using Csharp_design_patterns_lab.DesignPatterns.Structural.Adapter;
using Csharp_design_patterns_lab.DesignPatterns.Structural.Bridge;
using Csharp_design_patterns_lab.DesignPatterns.Structural.Composite;
using Csharp_design_patterns_lab.DesignPatterns.Structural.Decorator;
using Csharp_design_patterns_lab.DesignPatterns.Structural.Facade;
using System;

Console.WriteLine("C# Design Patterns Lab & Low-Level Design Repository\n");
Console.WriteLine("Select a Design Pattern to execute:");
Console.WriteLine("1. Singleton Pattern");
Console.WriteLine("2. Simple Factory Pattern");
Console.WriteLine("3. Factory Method Pattern");
Console.WriteLine("4. Abstract Factory Pattern");
Console.WriteLine("5. Prototype Pattern");
Console.WriteLine("6. Builder Pattern");
Console.WriteLine("7. Adapter Pattern");
Console.WriteLine("8. Bridge Pattern");
Console.WriteLine("9. Decorator Pattern");
Console.WriteLine("10. Facade Pattern");
Console.WriteLine("11. Composite Pattern");
Console.WriteLine("12. Command Pattern");
Console.WriteLine("13. Chain Of Responsibility Pattern");
Console.WriteLine("14. Strategy Pattern");
Console.WriteLine("15. Observer Pattern");
Console.WriteLine("16. State Pattern");
Console.WriteLine("17. Memento Pattern");
Console.WriteLine("18. Run All Patterns");
Console.WriteLine("0. Exit\n");

Console.Write("Enter option number: ");
string? input = Console.ReadLine();

Console.WriteLine();

switch (input?.Trim())
{
    case "1":
        SingletonDemo.Invoke();
        break;
    case "2":
        SimpleFactoryDemo.Invoke();
        break;
    case "3":
        FactoryMethodDemo.Invoke();
        break;
    case "4":
        AbstractFactoryDemo.Invoke();
        break;
    case "5":
        PrototypeDemo.Invoke();
        break;
    case "6":
        BuilderDemo.Invoke();
        break;
    case "7":
        AdapterDemo.Invoke();
        break;
    case "8":
        BridgeDemo.Invoke();
        break;
    case "9":
        DecoratorDemo.Invoke();
        break;
    case "10":
        FacadeDemo.Invoke();
        break;
    case "11":
        CompositeDemo.Invoke();
        break;
    case "12":
        Command.Invoke();
        break;
    case "13":
        ChainOfResponsbility.Invoke();
        break;
    case "14":
        StrategyDemo.Invoke();
        break;
    case "15":
        ObserverDemo.Invoke();
        break;
    case "16":
        StateDemo.Invoke();
        break;
    case "17":
        MementoDemo.Invoke();
        break;
    case "18":
        SingletonDemo.Invoke();
        SimpleFactoryDemo.Invoke();
        FactoryMethodDemo.Invoke();
        AbstractFactoryDemo.Invoke();
        PrototypeDemo.Invoke();
        BuilderDemo.Invoke();
        AdapterDemo.Invoke();
        BridgeDemo.Invoke();
        DecoratorDemo.Invoke();
        FacadeDemo.Invoke();
        CompositeDemo.Invoke();
        Command.Invoke();
        ChainOfResponsbility.Invoke();
        StrategyDemo.Invoke();
        ObserverDemo.Invoke();
        StateDemo.Invoke();
        MementoDemo.Invoke();
        break;
    case "0":
        Console.WriteLine("Exiting program.");
        return;
    default:
        Console.WriteLine("Invalid selection.");
        return;
}

Console.WriteLine("Execution completed successfully.");