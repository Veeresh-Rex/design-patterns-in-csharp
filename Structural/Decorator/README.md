# Decorator Pattern

## Intent
Attach additional responsibilities to an object dynamically. Decorators provide a flexible alternative to subclassing for extending functionality.

## When to Use
- To add responsibilities to individual objects dynamically and transparently, without affecting other objects.
- For responsibilities that can be withdrawn.
- When extension by subclassing is impractical or impossible due to a large number of independent extensions.

## Implementation details in this lab
- **Component Interface:** `ICharacter` defines `GetPower()`.
- **Concrete Component:** `Mario` provides base character power.
- **Decorator Base Class:** `PowerDecorator` wraps an `ICharacter` instance.
- **Concrete Decorators:**
  - `HeightUpPower`: Appends height boost capability.
  - `GunPower`: Appends weapon power capability.
- **Chained Decorators Demonstration:** Demonstrates stacking powers onto Mario dynamically.

## Output Trace
```
=== Decorator Pattern Demo ===
Mario
Mario Height up
Mario Height up With Gun
```
