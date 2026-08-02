# Bridge Pattern

## Intent
Decouple an abstraction from its implementation so that the two can vary independently.

## When to Use
- When you want to avoid a permanent binding between an abstraction and its implementation (e.g. when the implementation must be selected at run-time).
- When both the abstractions and their implementations should be extensible by subclassing.
- When changes in the implementation of an abstraction should have no impact on clients.
- To divide a monolithic class that has multiple variations of some functionality (e.g. different database servers, cross-platform UI frameworks).

## Implementation details in this lab
- **Abstraction Class:** `Shipment` defines the core entity structure.
- **Refined Abstractions:** `DomesticShipment` and `InternationalShipment` extend `Shipment` to implement specific business logic.
- **Implementor Interface:** `ILabelPrinter` defines the interface for label generation implementations.
- **Concrete Implementors:** `PdfPrinter` and `ZplPrinter` provide concrete output formats.
- **Bridge Design Benefit:** Subclasses delegate print logic directly to the encapsulated printer interface. Both dimensions (Shipment type and Printer format) can expand without creating a combinatorial explosion of subclasses (e.g. `DomesticPdfPrinter`, `DomesticZplPrinter`, etc.).

## Output Trace
```
=== Bridge Pattern Demo ===
Client: Printing domestic label via ZPL printer:
Domestic Shipment - ZPL Label Printed.

Client: Printing international label via PDF printer:
International Shipment - PDF Label Printed.
```
