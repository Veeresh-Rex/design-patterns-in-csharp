namespace Csharp_design_patterns_lab.Creational.Prototype;

public class Circle
{
    public int Radius { get; set; }
    
    public Circle(int radius)
    {
        Radius = radius;
    }
    
    public Circle Clone()
    {
        return MemberwiseClone() as Circle;
    }
}

public static class Prototype
{
    public static void Invoke()
    {
        Circle circle1 = new Circle(5);
        Circle circle2 = circle1.Clone();
        
        Console.WriteLine($"Circle 1 radius: {circle1.Radius}");
        Console.WriteLine($"Circle 2 radius: {circle2.Radius}");
        
        // change radius of circle2
        circle2.Radius = 10;
        
        Console.WriteLine($"Circle 1 radius after change: {circle1.Radius}");
        Console.WriteLine($"Circle 2 radius after change: {circle2.Radius}");
    }
}
