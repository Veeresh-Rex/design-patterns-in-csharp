namespace Csharp_design_patterns_lab.Creational.Factory_Method;

public interface IShape
{
    void Draw();
}

public class Circle : IShape
{
    public void Draw() { Console.WriteLine("This is circle"); }
}

public class Square: IShape
{
    public void Draw() { Console.WriteLine("This is square"); }
}

public class Triangle : IShape
{
    public void Draw() { Console.WriteLine("This is triangle"); }
}

public abstract class ShapeCreater
{
    public abstract IShape CreateShapeInstance();

    public void Draw() {
        IShape shape = CreateShapeInstance();
        shape.Draw();
    }
}

public class CircleCreator : ShapeCreater
{
    public override IShape CreateShapeInstance() => new Circle();
}

public class SquareCreator : ShapeCreater
{
    public override IShape CreateShapeInstance() => new Circle();
}

public class TriangleCreator : ShapeCreater
{
    public override IShape CreateShapeInstance() => new Triangle();
}


public static class FactoryMethod
{
    public static void Invoke()
    {
        ShapeCreater circle = new CircleCreator();
        circle.Draw();
    }
}
