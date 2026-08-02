namespace Csharp_design_patterns_lab.Creational.Simple_Factory;
//Not a GoF pattern — just a helper class with a static method. One class knows how to create everything.
//Simple, but violates Open/Closed Principle because adding a new type means editing the factory.

public interface IShape
{
    void Draw();
}

public class Circle : IShape
{
    public void Draw()
    {
        Console.WriteLine("This is Circle");
    }
}

public class Square : IShape
{
    public void Draw()
    {
        Console.WriteLine("This is Square");
    }
}


public class Triangle : IShape
{
    public void Draw()
    {
        Console.WriteLine("This is Triangle ");
    }
}

// Simple Factory — one class, one static method, switch on type
public class SimpleFactory
{
    public static IShape GetInstance(string shapeType)
    {
        return shapeType switch
        {
            "circle" => new Circle(),
            "square" => new Square(),
            "triangle" => new Triangle(),
            _ => throw new ArgumentException($"Unknown shape: {shapeType}")
        };
    }
}
