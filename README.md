# C# Design Patterns Lab

Welcome to the **C# Design Patterns Lab** repository! This project serves as a hands-on, executable reference guide to fundamental Software Design Patterns in C# (.NET 10). It is structured into Gang of Four (GoF) categories: **Creational**, **Structural**, and **Behavioral**.

Each pattern includes a complete C# implementation and a dedicated `README.md` detailing its intent, real-world applicability, implementation details, and output traces.

---

## 🚀 How to Run

To run the interactive demonstration CLI:

```bash
# Clone the repository
git clone <repository-url>
cd Csharp-design-patterns-lab

# Run the project
dotnet run
```

Upon launching, an interactive menu allows you to select and execute individual design pattern demonstrations or run all patterns sequentially:

```text
Select a Design Pattern to execute:
1. Singleton Pattern
2. Simple Factory Pattern
3. Factory Method Pattern
4. Abstract Factory Pattern
5. Prototype Pattern
6. Builder Pattern
7. Adapter Pattern
8. Bridge Pattern
9. Decorator Pattern
10. Facade Pattern
11. Command Pattern
12. Chain Of Responsibility Pattern
13. Run All Patterns
0. Exit
```

---

## 📂 Design Patterns Navigation

Navigate directly to any pattern's implementation code or documentation using the links below:

### 🏗️ Creational Patterns
Creational patterns deal with object creation mechanisms, trying to create objects in a manner suitable to the situation.

| Pattern | Code Implementation | Documentation | Description |
| :--- | :--- | :--- | :--- |
| **Singleton** | [Singleton.cs](./Creational/Singleton/Singleton.cs) | [README.md](./Creational/Singleton/README.md) | Ensures a class has only one instance and provides a global point of access to it. |
| **Simple Factory** | [SimpleFactory.cs](./Creational/Simple%20Factory/SimpleFactory.cs) | [README.md](./Creational/Simple%20Factory/README.md) | Encapsulates object instantiation logic into a single method based on criteria. |
| **Factory Method** | [FactoryMethod.cs](./Creational/Factory%20Method/FactoryMethod.cs) | [README.md](./Creational/Factory%20Method/README.md) | Defines an interface for creating objects, delegating instantiation to subclasses. |
| **Abstract Factory** | [AbstractFactory.cs](./Creational/Abstract%20Factory/AbstractFactory.cs) | [README.md](./Creational/Abstract%20Factory/README.md) | Creates families of related or dependent objects without specifying concrete classes. |
| **Prototype** | [Prototype.cs](./Creational/Prototype/Prototype.cs) | [README.md](./Creational/Prototype/README.md) | Creates new objects by cloning an existing prototypical instance (shallow & deep copy). |
| **Builder** | [Builder.cs](./Creational/Builder/Builder.cs) | [README.md](./Creational/Builder/README.md) | Constructs complex objects step-by-step, separating construction from representation. |

---

### 🏛️ Structural Patterns
Structural patterns deal with object composition or class inheritance to form larger, more flexible structures.

| Pattern | Code Implementation | Documentation | Description |
| :--- | :--- | :--- | :--- |
| **Adapter** | [Adapter.cs](./Structural/Adapter/Adapter.cs) | [README.md](./Structural/Adapter/README.md) | Converts the interface of a class into another interface expected by the client. |
| **Bridge** | [Bridge.cs](./Structural/Bridge/Bridge.cs) | [README.md](./Structural/Bridge/README.md) | Decouples an abstraction from its implementation so both can vary independently. |
| **Decorator** | [Decorator.cs](./Structural/Decorator/Decorator.cs) | [README.md](./Structural/Decorator/README.md) | Dynamically attaches additional responsibilities to an object at runtime. |
| **Facade** | [Facade.cs](./Structural/Facade/Facade.cs) | [README.md](./Structural/Facade/README.md) | Provides a simplified higher-level interface to a complex subsystem. |

---

### 🔄 Behavioral Patterns
Behavioral patterns focus on algorithms, assignments of responsibilities, and communication between objects.

| Pattern | Code Implementation | Documentation | Description |
| :--- | :--- | :--- | :--- |
| **Command** | [Command.cs](./Behavioral/Command/Command.cs) | [README.md](./Behavioral/Command/README.md) | Encapsulates a request as an object, enabling parameterization, queues, and undo operations. |
| **Chain of Responsibility** | [ChainOfResponsbility.cs](./Behavioral/ChainOfResponsibility/ChainOfResponsbility.cs) | [README.md](./Behavioral/ChainOfResponsibility/README.md) | Passes a request along a chain of handlers until one handles it or the chain ends. |

---

## 📐 Repository Architecture

```text
Csharp-design-patterns-lab/
├── Program.cs                         # Interactive CLI entry point
├── Creational/                        # Creational Design Patterns
│   ├── Abstract Factory/
│   ├── Builder/
│   ├── Factory Method/
│   ├── Prototype/
│   ├── Simple Factory/
│   └── Singleton/
├── Structural/                        # Structural Design Patterns
│   ├── Adapter/
│   ├── Bridge/
│   ├── Decorator/
│   └── Facade/
└── Behavioral/                        # Behavioral Design Patterns
    ├── ChainOfResponsibility/
    └── Command/
```

---

## 🛠️ Prerequisites

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download) (or compatible .NET version)
- Any modern C# IDE (Visual Studio, VS Code, JetBrains Rider)

---

## 🤝 Contributing & Extension

Feel free to add new design patterns (e.g., *Observer*, *Strategy*, *State*, *Composite*, *Flyweight*) by adding a new directory under the respective category folder containing:
1. `<PatternName>.cs` implementing the pattern along with an `Invoke()` method for the CLI trace.
2. `README.md` detailing the pattern's Intent, When to Use, Implementation details, and Output Trace.
3. Updating `Program.cs` menu options.
