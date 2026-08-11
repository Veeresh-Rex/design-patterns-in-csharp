# Memento Design Pattern

## Intent
Without violating encapsulation, capture and externalize an object's internal state so that the object can be restored to this state later.

## Implementation Details
- **Originator (`TextEditor`)**: Creates memento containing snapshot of current internal state.
- **Memento (`TextMemento`)**: Stores internal state of Originator.
- **Caretaker (`History`)**: Responsible for memento's safekeeping.
