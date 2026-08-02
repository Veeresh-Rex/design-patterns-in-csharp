# Adapter Pattern

## Intent
Convert the interface of a class into another interface clients expect. Adapter lets classes work together that couldn't otherwise because of incompatible interfaces.

## When to Use
- To use an existing class, and its interface does not match the one you need.
- To create a reusable class that cooperates with unrelated or unforeseen classes.

## Implementation details in this lab
- **Target Interface:** `ITargetBillingProcessor` defines `ProcessPayment(string clientJsonData)`.
- **Adaptee:** `LegacyBillingSystem` processes payments via `ProcessLegacyPayment(string clientXmlData)`.
- **Adapter:** `BillingAdapter` implements `ITargetBillingProcessor`, converts JSON request data into XML, and delegates execution to `LegacyBillingSystem`.

## Output Trace
```
Adapter Pattern:
Sending payment request in JSON format...
Translating JSON to XML...
Processing payment using XML data:
    Data: <payment><amount>250.00</amount><currency>USD</currency></payment>
```
