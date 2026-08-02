using System;

namespace Csharp_design_patterns_lab.Creational.Singleton;

public class Singleton
{
    private static readonly Singleton _instance = new Singleton();

    private Singleton()
    {
    }

    public static Singleton Instance => _instance;

    public void PrintMethod()
    {
        Console.WriteLine("This is a method in the Singleton class.");
    }
}

public static class SingletonDemo
{
    public static void Invoke()
    {
        Console.WriteLine("Singleton Pattern:");
        
        Singleton s1 = Singleton.Instance;
        Singleton s2 = Singleton.Instance;

        s1.PrintMethod();

        if (ReferenceEquals(s1, s2))
        {
            Console.WriteLine("Success: Both variables hold the exact same instance reference.");
        }
        else
        {
            throw new InvalidOperationException("Singleton instances are not identical.");
        }

        Console.WriteLine();
    }
}
