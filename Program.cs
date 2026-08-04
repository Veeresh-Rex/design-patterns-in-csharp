using Csharp_design_patterns_lab.Behavioral.ChainOfResponsibility;
using Csharp_design_patterns_lab.Behavioral.Command;
using Csharp_design_patterns_lab.Creational.Abstract_Factory;
using Csharp_design_patterns_lab.Creational.Builder;
using Csharp_design_patterns_lab.Creational.Factory_Method;
using Csharp_design_patterns_lab.Creational.Prototype;
using Csharp_design_patterns_lab.Creational.Simple_Factory;
using Csharp_design_patterns_lab.Creational.Singleton;
using Csharp_design_patterns_lab.Structural.Adapter;
using Csharp_design_patterns_lab.Structural.Bridge;
using Csharp_design_patterns_lab.Structural.Decorator;
using Csharp_design_patterns_lab.Structural.Facade;
using System;

Console.WriteLine("C# Design Patterns Lab\n");
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
Console.WriteLine("11. Command Pattern");
Console.WriteLine("12. Chain Of Responsbility Pattern");
Console.WriteLine("13. Run All Patterns");
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
        Command.Invoke();
        break;
    case "12":
        ChainOfResponsbility.Invoke();
        break;
    case "13":
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
        Command.Invoke();
        break;
    case "0":
        Console.WriteLine("Exiting program.");
        return;
    default:
        Console.WriteLine("Invalid selection.");
        return;
}

Console.WriteLine("Execution completed successfully.");