# State Design Pattern

## Intent
Allow an object to alter its behavior when its internal state changes. The object will appear to change its class.

## Implementation Details
- **Context (`VendingMachine`)**: Defines client interface and maintains state instance.
- **State Interface (`IVendingMachineState`)**: Common interface for state-specific behavior.
- **Concrete States (`NoCoinState`, `HasCoinState`)**: Implement behavior associated with a state.
