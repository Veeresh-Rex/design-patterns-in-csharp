# Abstract Factory Pattern

## Intent
Provide an interface for creating families of related or dependent objects without specifying their concrete classes.

## When to Use
- When a system should be independent of how its products are created, composed, and represented.
- When a system should be configured with one of multiple families of products.
- When a family of related product objects is designed to be used together, and you need to enforce this constraint.

## Implementation details in this lab
- **Abstract Products:** `ILabelGenerator` (Product A) and `IRateCalculator` (Product B).
- **Product Families:** 
  - USPS: `USPSLabelGenerator` and `USPSRating`.
  - FedEx: `FedExLabelGenerator` and `FedExRating`.
- **Abstract Factory:** `ICarrierFactory` declares creation methods for both product types.
- **Concrete Factories:** `UspsFactory` and `FedExFactory` construct USPS and FedEx products respectively.

## Output Trace
```
=== Abstract Factory Pattern Demo ===
Client: Working with USPS factory...
Calculating USPS shipping rate.
Generating USPS shipping label.

Client: Working with FedEx factory...
Calculating FedEx shipping rate.
Generating FedEx shipping label.
```
