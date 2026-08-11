# Singleton Pattern

## Intent
Ensure a class only has one instance, and provide a global point of access to it.

## When to Use
- When there must be exactly one instance of a class, and it must be accessible to clients from a well-known access point.
- When the sole instance should be extensible by subclassing, and clients should be able to use an extended instance without modifying their code.
- Examples: Logging services, database connection pools, thread pools, or configuration managers.

## Implementation details in this lab
- **Thread-Safety:** C# guarantees thread-safe initialization of static fields when the class is loaded, making the `static readonly Singleton` instantiation safe without explicit lock blocks.
- **Private Constructor:** The parameterless constructor is marked `private` to prevent manual initialization from outside.
- **Static Property:** The `Instance` property serves as the global access point to retrieve the single instance.

## Output Trace
```
=== Singleton Pattern Demo ===
This is a method in the Singleton class.
Success: Both variables hold the exact same instance reference.
```
