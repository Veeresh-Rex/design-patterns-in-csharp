# Observer Design Pattern

## Intent
Define a one-to-many dependency between objects so that when one object changes state, all its dependents are notified and updated automatically.

## Implementation Details
- **Subject (`StockTicker`)**: Maintains list of observers and notifies them on change.
- **Observer (`IObserver`, `Investor`)**: Receives updates from subject.
