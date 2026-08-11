# Builder Pattern

## Intent
Separate the construction of a complex object from its representation so that the same construction process can create different representations.

## When to Use
- When the algorithm for creating a complex object should be independent of the parts that make up the object and how they are assembled.
- When the construction process must allow different representations for the object that is constructed (e.g. constructing products with different optional settings).
- To avoid "telescoping constructor" anti-pattern where a class has many constructors with varying parameter counts.

## Implementation details in this lab
- **Product Class:** `Shipment` represents a complex shipping entity with several parameters (Carrier, Weight, IsSignatureRequired).
- **Fluent Builder:** `ShipmentBuilder` accumulates builder properties using fluent chaining methods (`WithCarrier()`, `WithWeight()`, `WithSignatureRequired()`).
- **State Safety:** The builder creates a brand-new instance of `Shipment` inside `Build()` and calls `Reset()` to clear its properties. This ensures the builder can be safely reused to construct multiple independent shipments.

## Output Trace
```
=== Builder Pattern Demo ===
Shipment 1 built: Shipment [Carrier=USPS, Weight=10.97 lbs, SignatureRequired=True]
Shipment 2 built: Shipment [Carrier=FedEx, Weight=2.5 lbs, SignatureRequired=False]
```
