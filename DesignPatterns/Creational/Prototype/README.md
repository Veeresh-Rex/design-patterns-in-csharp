# Prototype Pattern

## Intent
Specify the kinds of objects to create using a prototypical instance, and create new objects by copying this prototype.

## When to Use
- When the classes to instantiate are specified at run-time (e.g. by dynamic loading).
- To avoid building a class hierarchy of factories that parallels the class hierarchy of products.
- When instances of a class can have one of only a few different combinations of state. It may be more convenient to install a corresponding number of prototypes and clone them rather than instantiating the class manually.

## Implementation details in this lab
- **Generic Prototype Interface:** `IPrototype<T>` defines a generic `Clone()` contract.
- **Reference Nested Property:** `BorderDetails` represents a nested reference-type field, useful for showing the difference between shallow and deep copying.
- **Shallow Copy (`Clone()`):** Uses C#'s built-in `MemberwiseClone()`. For reference types, only the reference pointer is copied, causing mutations on the clone's reference fields to affect the original object.
- **Deep Copy (`DeepClone()`):** Clones primitive fields and recursively instantiates new copies of reference fields (e.g., `new BorderDetails(...)`), isolating the original object from clone mutations.

## Output Trace
```
=== Prototype Pattern Demo ===
--- Shallow Copy Demonstration ---
Original Circle: Radius=5, Border Color=Red
Shallow Cloned Circle: Radius=5, Border Color=Red

After modifying the shallow clone's properties:
Original Circle: Radius=5 (Unchanged), Border Color=Blue (MUTATED!)
Shallow Cloned Circle: Radius=10, Border Color=Blue

--- Deep Copy Demonstration ---
Original Circle: Radius=5, Border Color=Red
Deep Cloned Circle: Radius=5, Border Color=Red

After modifying the deep clone's properties:
Original Circle: Radius=5 (Unchanged), Border Color=Red (UNCHANGED!)
Deep Cloned Circle: Radius=10, Border Color=Green
```
