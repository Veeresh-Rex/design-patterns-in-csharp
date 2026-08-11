# Low-Level Design (LLD) Interview Checklist

Follow this systematic step-by-step checklist when solving LLD interview problems.

---

## 1. Requirement Gathering & Scope Definition
- [ ] Clarify Core Functional Requirements (Use Cases)
- [ ] Identify Non-Functional Requirements (Concurrency, Extensibility, Scalability, Memory)
- [ ] Define Out-of-Scope items explicitly

## 2. Entity Identification & Enums
- [ ] Identify Primary Actors and Domain Models
- [ ] Define System Status / Types as Enums (e.g., `VehicleType`, `PaymentStatus`)

## 3. Core Class Design & Relations
- [ ] Define Interfaces and Abstract Classes (`IParkingLotService`, `INotificationChannel`)
- [ ] Map Relationships (Inheritance, Composition, Aggregation)
- [ ] Apply SOLID Principles (SRP, OCP, DIP)

## 4. Design Pattern Selection
- [ ] Apply Creational Patterns (Factory, Builder, Singleton)
- [ ] Apply Structural Patterns (Adapter, Decorator, Facade)
- [ ] Apply Behavioral Patterns (Strategy, Observer, State)

## 5. Thread Safety & Concurrency
- [ ] Use `lock` / `Monitor` or thread-safe collections (`ConcurrentDictionary`) where necessary
- [ ] Ensure stateless services where possible

## 6. Implementation
- [ ] Implement clean domain model code with C# properties & validation
