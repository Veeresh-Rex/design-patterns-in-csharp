using System;

namespace Csharp_design_patterns_lab.Creational.Prototype;

public interface IPrototype<out T>
{
    T Clone();
}

public class BorderDetails
{
    public string Color { get; set; }

    public BorderDetails(string color)
    {
        Color = color;
    }
}

public class Circle : IPrototype<Circle>
{
    public int Radius { get; set; }
    public BorderDetails Border { get; set; }

    public Circle(int radius, string borderColor)
    {
        Radius = radius;
        Border = new BorderDetails(borderColor);
    }

    public Circle Clone()
    {
        return (Circle)this.MemberwiseClone();
    }

    public Circle DeepClone()
    {
        Circle clone = (Circle)this.MemberwiseClone();
        clone.Border = new BorderDetails(this.Border.Color);
        return clone;
    }
}

public static class PrototypeDemo
{
    public static void Invoke()
    {
        Console.WriteLine("Prototype Pattern:");

        Console.WriteLine("Shallow Copy Demonstration:");
        Circle circle1 = new Circle(5, "Red");
        Circle circle2 = circle1.Clone();

        Console.WriteLine($"Original Circle: Radius={circle1.Radius}, Border Color={circle1.Border.Color}");
        Console.WriteLine($"Shallow Cloned Circle: Radius={circle2.Radius}, Border Color={circle2.Border.Color}");

        circle2.Radius = 10;
        circle2.Border.Color = "Blue";

        Console.WriteLine("\nAfter modifying the shallow clone's properties:");
        Console.WriteLine($"Original Circle: Radius={circle1.Radius} (Unchanged), Border Color={circle1.Border.Color} (MUTATED!)");
        Console.WriteLine($"Shallow Cloned Circle: Radius={circle2.Radius}, Border Color={circle2.Border.Color}");

        Console.WriteLine();

        Console.WriteLine("Deep Copy Demonstration:");
        Circle circle3 = new Circle(5, "Red");
        Circle circle4 = circle3.DeepClone();

        Console.WriteLine($"Original Circle: Radius={circle3.Radius}, Border Color={circle3.Border.Color}");
        Console.WriteLine($"Deep Cloned Circle: Radius={circle4.Radius}, Border Color={circle4.Border.Color}");

        circle4.Radius = 10;
        circle4.Border.Color = "Green";

        Console.WriteLine("\nAfter modifying the deep clone's properties:");
        Console.WriteLine($"Original Circle: Radius={circle3.Radius} (Unchanged), Border Color={circle3.Border.Color} (UNCHANGED!)");
        Console.WriteLine($"Deep Cloned Circle: Radius={circle4.Radius}, Border Color={circle4.Border.Color}");

        Console.WriteLine();
    }
}
