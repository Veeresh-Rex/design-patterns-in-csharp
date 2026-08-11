# Command Pattern

## Intent
Encapsulate a request as an object, thereby letting you parameterize clients with different requests, queue or log requests, and support undoable operations.

## When to Use
- To parameterize objects by an action to perform (callbacks).
- To specify, queue, and execute requests at different times.
- To support undo/redo capabilities.
- To support logging changes so that they can be reapplied in case of a system crash.

## Implementation details in this lab
- **Command Interface:** `ICommand` defines `Execute()` and `Undo()`.
- **Receivers:** `Light` and `Fan`.
- **Concrete Commands:**
  - `LightOnCommand` and `LightOffCommand`.
  - `FanOnCommand` and `FanOffCommand`.
  - `FanIncreaseSpeedCommand`: Increases speed by 1 up to maximum speed (5).
  - `FanDecreaseSpeedCommand`: Decreases speed by 1 down to minimum speed (0).
- **Invoker (`Remote`):** Maintains button slot assignments and a `Stack<ICommand>` history for Undo functionality.

## Output Trace
```
Command Pattern:
Button 0 pressed: Light is ON.
Button 2 pressed: Fan is ON (Speed: 1).
Button 4 pressed: Fan speed increased to 2.
Button 4 pressed: Fan speed increased to 3.
Button 5 pressed: Fan speed decreased to 2.
Undo pressed: Fan speed set to 3.
Undo pressed: Fan speed set to 2.
Button 1 pressed: Light is OFF.
Button 3 pressed: Fan is OFF.
```
