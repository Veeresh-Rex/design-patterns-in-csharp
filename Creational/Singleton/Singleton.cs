namespace Csharp_design_patterns_lab.Creational.Singleton;

public class Singleton
{
    private static  readonly Singleton _instance = new Singleton();
    private Singleton()
    {

    }
    public static Singleton Instance => _instance;

    public void PrintMethod() => Console.WriteLine("This is a method in the Singleton class.");
}
