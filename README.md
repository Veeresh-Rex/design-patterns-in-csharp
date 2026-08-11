# LLD-CSharp: Design Patterns & Low-Level Design Lab

Welcome to **LLD-CSharp**! This repository is a comprehensive, structured reference guide and hands-on lab for **Software Design Patterns** and **Low-Level System Design (LLD)** in C# (.NET 10).

---

## 📂 Repository Structure

```text
LLD-CSharp/
│
├── README.md
├── Csharp-design-patterns-lab.sln
│
├── DesignPatterns/
│   ├── Creational/
│   │   ├── AbstractFactory/
│   │   ├── Builder/
│   │   ├── Factory/
│   │   ├── Prototype/
│   │   ├── SimpleFactory/
│   │   └── Singleton/
│   │
│   ├── Structural/
│   │   ├── Adapter/
│   │   ├── Bridge/
│   │   ├── Composite/
│   │   ├── Decorator/
│   │   └── Facade/
│   │
│   └── Behavioral/
│       ├── ChainOfResponsibility/
│       ├── Command/
│       ├── Memento/
│       ├── Observer/
│       ├── State/
│       └── Strategy/
│
├── Problems/
│   └── 01_DocumentEditor/
│       ├── DocumentEditor.sln
│       ├── src/DocumentEditor/
│       │   ├── Elements/
│       │   ├── Interfaces/
│       │   ├── Models/
│       │   ├── Repositories/
│       │   ├── Services/
│       │   └── Program.cs
│       └── tests/DocumentEditor.Tests/
│
└── Notes/
    ├── SOLID.md
    ├── OOP.md
    ├── UML.md
    └── LLD-Checklist.md
```

---

## 🚀 Getting Started

```bash
# Clone the repository
git clone <repository-url>
cd Csharp-design-patterns-lab

# Build and run the interactive Design Patterns CLI
dotnet build
dotnet run
```

Upon launching `dotnet run`, an interactive CLI menu allows executing individual design pattern demonstrations or running all patterns sequentially:

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
11. Composite Pattern
12. Command Pattern
13. Chain Of Responsibility Pattern
14. Strategy Pattern
15. Observer Pattern
16. State Pattern
17. Memento Pattern
18. Run All Patterns
0. Exit
```

---

## 🏛️ Design Patterns Index

### 🏗️ Creational Patterns
Deal with object creation mechanisms to increase flexibility and reuse of existing code.

| Pattern | Code Implementation | Documentation | Description |
| :--- | :--- | :--- | :--- |
| **Singleton** | [Singleton.cs](./DesignPatterns/Creational/Singleton/Singleton.cs) | [README.md](./DesignPatterns/Creational/Singleton/README.md) | Ensures a class has only one instance and provides global access. |
| **Simple Factory** | [SimpleFactory.cs](./DesignPatterns/Creational/SimpleFactory/SimpleFactory.cs) | [README.md](./DesignPatterns/Creational/SimpleFactory/README.md) | Encapsulates object instantiation logic into a single factory method. |
| **Factory Method** | [FactoryMethod.cs](./DesignPatterns/Creational/Factory/FactoryMethod.cs) | [README.md](./DesignPatterns/Creational/Factory/README.md) | Defines an interface for object creation, delegating instantiation to subclasses. |
| **Abstract Factory** | [AbstractFactory.cs](./DesignPatterns/Creational/AbstractFactory/AbstractFactory.cs) | [README.md](./DesignPatterns/Creational/AbstractFactory/README.md) | Produces families of related objects without specifying concrete classes. |
| **Prototype** | [Prototype.cs](./DesignPatterns/Creational/Prototype/Prototype.cs) | [README.md](./DesignPatterns/Creational/Prototype/README.md) | Copies existing objects without making code dependent on their classes. |
| **Builder** | [Builder.cs](./DesignPatterns/Creational/Builder/Builder.cs) | [README.md](./DesignPatterns/Creational/Builder/README.md) | Constructs complex objects step-by-step. |

### 🏛️ Structural Patterns
Explain how to assemble objects and classes into larger structures while keeping these structures flexible and efficient.

| Pattern | Code Implementation | Documentation | Description |
| :--- | :--- | :--- | :--- |
| **Adapter** | [Adapter.cs](./DesignPatterns/Structural/Adapter/Adapter.cs) | [README.md](./DesignPatterns/Structural/Adapter/README.md) | Allows objects with incompatible interfaces to collaborate. |
| **Bridge** | [Bridge.cs](./DesignPatterns/Structural/Bridge/Bridge.cs) | [README.md](./DesignPatterns/Structural/Bridge/README.md) | Splits a large class or set of related classes into two separate hierarchies. |
| **Composite** | [Composite.cs](./DesignPatterns/Structural/Composite/Composite.cs) | [README.md](./DesignPatterns/Structural/Composite/README.md) | Composes objects into tree structures to represent part-whole hierarchies. |
| **Decorator** | [Decorator.cs](./DesignPatterns/Structural/Decorator/Decorator.cs) | [README.md](./DesignPatterns/Structural/Decorator/README.md) | Attaches new behaviors to objects by placing them inside special wrapper objects. |
| **Facade** | [Facade.cs](./DesignPatterns/Structural/Facade/Facade.cs) | [README.md](./DesignPatterns/Structural/Facade/README.md) | Provides a simplified interface to a library, a framework, or any complex set of classes. |

### 🔄 Behavioral Patterns
Take care of effective communication and the assignment of responsibilities between objects.

| Pattern | Code Implementation | Documentation | Description |
| :--- | :--- | :--- | :--- |
| **Chain of Responsibility** | [ChainOfResponsbility.cs](./DesignPatterns/Behavioral/ChainOfResponsibility/ChainOfResponsbility.cs) | [README.md](./DesignPatterns/Behavioral/ChainOfResponsibility/README.md) | Passes requests along a chain of handlers. |
| **Command** | [Command.cs](./DesignPatterns/Behavioral/Command/Command.cs) | [README.md](./DesignPatterns/Behavioral/Command/README.md) | Turns a request into a stand-alone object containing all information about the request. |
| **Memento** | [Memento.cs](./DesignPatterns/Behavioral/Memento/Memento.cs) | [README.md](./DesignPatterns/Behavioral/Memento/README.md) | Saves and restores the previous state of an object without revealing implementation details. |
| **Observer** | [Observer.cs](./DesignPatterns/Behavioral/Observer/Observer.cs) | [README.md](./DesignPatterns/Behavioral/Observer/README.md) | Subscription mechanism to notify multiple objects about events. |
| **State** | [State.cs](./DesignPatterns/Behavioral/State/State.cs) | [README.md](./DesignPatterns/Behavioral/State/README.md) | Lets an object alter its behavior when its internal state changes. |
| **Strategy** | [Strategy.cs](./DesignPatterns/Behavioral/Strategy/Strategy.cs) | [README.md](./DesignPatterns/Behavioral/Strategy/README.md) | Defines a family of algorithms, puts each into a separate class, and makes objects interchangeable. |

---

## 🛠️ Low-Level Design Problems

| # | Problem | Solution | Tests | Description |
|---|---|---|---|---|
| 01 | **DocumentEditor** | [DocumentEditor.sln](./Problems/01_DocumentEditor/DocumentEditor.sln) | [DocumentEditor.Tests](./Problems/01_DocumentEditor/tests/DocumentEditor.Tests) | Rich document composition editor with text, images, blob storage, and DB persistence. |

---

## 📚 Study Notes

- 📘 [SOLID Principles](./Notes/SOLID.md)
- 📗 [OOP Fundamentals](./Notes/OOP.md)
- 📙 [UML Diagrams Guide](./Notes/UML.md)
- 📓 [LLD Interview Checklist](./Notes/LLD-Checklist.md)
