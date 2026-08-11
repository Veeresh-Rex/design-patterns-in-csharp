# Strategy Design Pattern

## Intent
Define a family of algorithms, encapsulate each one, and make them interchangeable. Strategy lets the algorithm vary independently from clients that use it.

## Implementation Details
- **Strategy Interface (`IPaymentStrategy`)**: Common interface for all supported algorithms.
- **Concrete Strategies**: `CreditCardPayment`, `PayPalPayment`, `CryptoPayment`.
- **Context (`ShoppingCart`)**: Maintains a reference to a Strategy object.
