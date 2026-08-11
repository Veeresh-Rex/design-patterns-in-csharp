namespace Csharp_design_patterns_lab.DesignPatterns.Behavioral.Command;

public interface ICommand
{
    void Execute();
    void Undo();
}

public class Light
{
    public void On()
    {
        Console.WriteLine("Light is ON.");
    }

    public void Off()
    {
        Console.WriteLine("Light is OFF.");
    }
}

public class Fan
{
    public const int MinSpeed = 0;
    public const int MaxSpeed = 5;

    public int Speed { get; private set; } = 0;

    public void On()
    {
        if (Speed == 0)
        {
            Speed = 1;
        }
        Console.WriteLine($"Fan is ON (Speed: {Speed}).");
    }

    public void Off()
    {
        Speed = 0;
        Console.WriteLine("Fan is OFF.");
    }

    public void IncreaseSpeed()
    {
        if (Speed < MaxSpeed)
        {
            Speed++;
            Console.WriteLine($"Fan speed increased to {Speed}.");
        }
        else
        {
            Console.WriteLine($"Fan is already at maximum speed ({MaxSpeed}).");
        }
    }

    public void DecreaseSpeed()
    {
        if (Speed > MinSpeed)
        {
            Speed--;
            Console.WriteLine($"Fan speed decreased to {Speed}.");
        }
        else
        {
            Console.WriteLine($"Fan is already at minimum speed ({MinSpeed}).");
        }
    }

    public void SetSpeed(int speed)
    {
        Speed = Math.Clamp(speed, MinSpeed, MaxSpeed);
        Console.WriteLine($"Fan speed set to {Speed}.");
    }
}

public class LightOnCommand : ICommand
{
    private readonly Light _light;

    public LightOnCommand(Light light)
    {
        _light = light ?? throw new ArgumentNullException(nameof(light));
    }

    public void Execute() => _light.On();
    public void Undo() => _light.Off();
}

public class LightOffCommand : ICommand
{
    private readonly Light _light;

    public LightOffCommand(Light light)
    {
        _light = light ?? throw new ArgumentNullException(nameof(light));
    }

    public void Execute() => _light.Off();
    public void Undo() => _light.On();
}

public class FanOnCommand : ICommand
{
    private readonly Fan _fan;

    public FanOnCommand(Fan fan)
    {
        _fan = fan ?? throw new ArgumentNullException(nameof(fan));
    }

    public void Execute() => _fan.On();
    public void Undo() => _fan.Off();
}

public class FanOffCommand : ICommand
{
    private readonly Fan _fan;

    public FanOffCommand(Fan fan)
    {
        _fan = fan ?? throw new ArgumentNullException(nameof(fan));
    }

    public void Execute() => _fan.Off();
    public void Undo() => _fan.On();
}

public class FanIncreaseSpeedCommand : ICommand
{
    private readonly Fan _fan;
    private int _prevSpeed;

    public FanIncreaseSpeedCommand(Fan fan)
    {
        _fan = fan ?? throw new ArgumentNullException(nameof(fan));
    }

    public void Execute()
    {
        _prevSpeed = _fan.Speed;
        _fan.IncreaseSpeed();
    }

    public void Undo()
    {
        _fan.SetSpeed(_prevSpeed);
    }
}

public class FanDecreaseSpeedCommand : ICommand
{
    private readonly Fan _fan;
    private int _prevSpeed;

    public FanDecreaseSpeedCommand(Fan fan)
    {
        _fan = fan ?? throw new ArgumentNullException(nameof(fan));
    }

    public void Execute()
    {
        _prevSpeed = _fan.Speed;
        _fan.DecreaseSpeed();
    }

    public void Undo()
    {
        _fan.SetSpeed(_prevSpeed);
    }
}

public class Remote
{
    private const int NumOfButtons = 6;
    private readonly ICommand[] _commands = new ICommand[NumOfButtons];
    private readonly Stack<ICommand> _history = new Stack<ICommand>();

    public void SetCommandButton(ICommand command, int index)
    {
        if (index < 0 || index >= NumOfButtons)
        {
            throw new ArgumentOutOfRangeException(nameof(index), $"Button index {index} is out of bounds.");
        }

        _commands[index] = command;
    }

    public void PressButton(int index)
    {
        if (index < 0 || index >= NumOfButtons)
        {
            throw new ArgumentOutOfRangeException(nameof(index), $"Button index {index} is out of bounds.");
        }

        var command = _commands[index];
        if (command == null)
        {
            return;
        }

        Console.Write($"Button {index} pressed: ");
        command.Execute();
        _history.Push(command);
    }

    public void PressUndo()
    {
        if (_history.Count == 0)
        {
            return;
        }

        var command = _history.Pop();
        Console.Write("Undo pressed: ");
        command.Undo();
    }
}

public class Command
{
    public static void Invoke()
    {
        Console.WriteLine("Command Pattern:");

        Remote remote = new Remote();
        Light livingRoomLight = new Light();
        Fan ceilingFan = new Fan();

        remote.SetCommandButton(new LightOnCommand(livingRoomLight), 0);
        remote.SetCommandButton(new LightOffCommand(livingRoomLight), 1);
        remote.SetCommandButton(new FanOnCommand(ceilingFan), 2);
        remote.SetCommandButton(new FanOffCommand(ceilingFan), 3);
        remote.SetCommandButton(new FanIncreaseSpeedCommand(ceilingFan), 4);
        remote.SetCommandButton(new FanDecreaseSpeedCommand(ceilingFan), 5);

        remote.PressButton(0);
        remote.PressButton(2);
        remote.PressButton(4);
        remote.PressButton(4);
        remote.PressButton(5);

        remote.PressUndo();
        remote.PressUndo();

        remote.PressButton(1);
        remote.PressButton(3);

        Console.WriteLine();
    }
}
