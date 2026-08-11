using System;

namespace Csharp_design_patterns_lab.DesignPatterns.Creational.Factory;

public interface IShape
{
    void Draw();
}

public class Circle : IShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing a Circle (via Factory Method).");
    }
}

public class Square : IShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing a Square (via Factory Method).");
    }
}

public class Triangle : IShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing a Triangle (via Factory Method).");
    }
}

public abstract class ShapeCreator
{
    public abstract IShape CreateShapeInstance();

    public void Render()
    {
        IShape shape = CreateShapeInstance();
        shape.Draw();
    }
}

public class CircleCreator : ShapeCreator
{
    public override IShape CreateShapeInstance() => new Circle();
}

public class SquareCreator : ShapeCreator
{
    public override IShape CreateShapeInstance() => new Square();
}

public class TriangleCreator : ShapeCreator
{
    public override IShape CreateShapeInstance() => new Triangle();
}

public static class FactoryMethodDemo
{
    public static void Invoke()
    {
        Console.WriteLine("Factory Method Pattern:");

        ShapeCreator circleCreator = new CircleCreator();
        circleCreator.Render();

        ShapeCreator squareCreator = new SquareCreator();
        squareCreator.Render();

        ShapeCreator triangleCreator = new TriangleCreator();
        triangleCreator.Render();

        Console.WriteLine();
    }
}
