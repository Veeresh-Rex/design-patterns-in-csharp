# Factory Method Pattern

## Intent
Define an interface for creating an object, but let subclasses decide which class to instantiate. The Factory Method lets a class defer instantiation to subclasses.

## When to Use
- When a class cannot anticipate the class of objects it must create.
- When a class wants its subclasses to specify the objects it creates.
- When you want to localize the responsibility of helper subclasses.

## Implementation details in this lab
- **Product Interface:** `IShape` defines the drawing behavior.
- **Concrete Products:** `Circle`, `Square`, and `Triangle` implement `IShape`.
- **Creator Base Class:** `ShapeCreator` defines the abstract factory method `CreateShapeInstance()` and a concrete `Render()` method that calls it.
- **Concrete Creators:** `CircleCreator`, `SquareCreator`, and `TriangleCreator` implement `CreateShapeInstance()` to return their respective shapes.

## Output Trace
```
=== Factory Method Pattern Demo ===
Drawing a Circle (via Factory Method).
Drawing a Square (via Factory Method).
Drawing a Triangle (via Factory Method).
```
