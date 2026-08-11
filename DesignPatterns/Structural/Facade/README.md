# Facade Pattern

## Intent
Provide a unified interface to a set of interfaces in a subsystem. Facade defines a higher-level interface that makes the subsystem easier to use.

## When to Use
- When you want to provide a simple interface to a complex subsystem. Subsystems often get more complex as they evolve. Most patterns, when applied, result in more and smaller classes. This makes the subsystem more reusable and easier to customize, but it also becomes harder to use for clients that don't need to customize it.
- When there are many dependencies between clients and the implementation classes of an abstraction. Introduce a facade to decouple the subsystem from clients and other subsystems.
- When you want to layer your subsystems. Use a facade to define an entry point to each subsystem level.

## Implementation details in this lab
- **Subsystem Class:** `Computer` implements low-level functions like drawing electric shock, POST test, booting files, loading screens, spin down, and pulling current.
- **Facade Class:** `ComputerFacade` simplifies the boot and shutdown procedures by exposing single operations (`TurnOn()` and `TurnOff()`), coordinating all operations behind the scenes.

## Output Trace
```
=== Facade Pattern Demo ===
[Facade] Booting system...
Ouch! Static electricity shock.
Beep beep! POST passed.
Loading operating system...
Ready to be used!

[Facade] Shutting down system...
Closing running applications...
Cutting power. Haaah!
Spinning down hard drives (Zzzzz)...
```
