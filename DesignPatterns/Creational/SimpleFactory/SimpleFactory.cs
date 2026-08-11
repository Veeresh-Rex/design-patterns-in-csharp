using System;

namespace Csharp_design_patterns_lab.DesignPatterns.Creational.SimpleFactory;

public interface IShape
{
    void Draw();
}

public class Circle : IShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing a Circle.");
    }
}

public class Square : IShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing a Square.");
    }
}

public class Triangle : IShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing a Triangle.");
    }
}

public class SimpleFactory
{
    public static IShape GetInstance(string shapeType)
    {
        return shapeType.ToLowerInvariant() switch
        {
            "circle" => new Circle(),
            "square" => new Square(),
            "triangle" => new Triangle(),
            _ => throw new ArgumentException($"Unknown shape type: {shapeType}")
        };
    }
}

public static class SimpleFactoryDemo
{
    public static void Invoke()
    {
        Console.WriteLine("Simple Factory Pattern:");
        
        try
        {
            IShape circle = SimpleFactory.GetInstance("circle");
            circle.Draw();

            IShape square = SimpleFactory.GetInstance("square");
            square.Draw();

            IShape triangle = SimpleFactory.GetInstance("triangle");
            triangle.Draw();

            SimpleFactory.GetInstance("hexagon");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Expected exception caught: {ex.Message}");
        }

        Console.WriteLine();
    }
}
