# Simple Factory Pattern

## Intent
Provide a centralized interface/class that encapsulates the instantiation logic of a set of related classes based on given input.

## When to Use
- When you want to isolate the client code from the concrete classes it needs to instantiate.
- When the creation logic is simple, and you want to delegate it to a helper class.
- *Note:* Simple Factory is not a classic GoF design pattern, but rather a common programming idiom. It violates the Open/Closed Principle (OCP) because adding a new product type requires modifying the factory class's switch/creation logic.

## Implementation details in this lab
- **Product Interface:** `IShape` defines the common draw interface.
- **Concrete Products:** `Circle`, `Square`, and `Triangle` implement `IShape`.
- **Factory:** `SimpleFactory` exposes a static `GetInstance(string shapeType)` method that handles parsing and instantiation using switch expressions.

## Output Trace
```
=== Simple Factory Pattern Demo ===
Drawing a Circle.
Drawing a Square.
Drawing a Triangle.
Expected exception caught: Unknown shape type: hexagon
```
