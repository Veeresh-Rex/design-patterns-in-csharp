namespace Csharp_design_patterns_lab.Behavioral.Command;

public interface ICommand
{
    void Execute();
    void Undo();
}

public class Light
{
    public void On()
    {
        Console.WriteLine("Turning on bulb");
    }

    public void Off()
    {
        Console.WriteLine("Turining Off bulb");
    }
}

public class Fan
{
    public void On()
    {
        Console.WriteLine("Turning on Fan");
    }

    public void Off()
    {
        Console.WriteLine("Turining Off Fan");
    }

    public void IncreaseSpeed(int speed)
    {
        Console.WriteLine($"Incresed fan speed to {speed}");
    }

    public void DecreseFanSpeed(int speed)
    {
        Console.WriteLine($"Decreased Fan speed to {speed}");
    }
}

public class LightCommand : ICommand
{
    private readonly Light light;
    public LightCommand(Light light)
    {
        this.light = light;
    }

    public void Execute()
    {
        light.On();
    }

    public void Undo()
    {
        light.Off();
    }
}


public class FanCommand : ICommand
{
    private readonly Fan fan;
    public FanCommand(Fan fan)
    {
        this.fan = fan;
    }

    public void Execute()
    {
        fan.On();
    }

    public void Undo()
    {
        fan.Off();
    }
}

public class Remote
{
    private const int numOfButtons = 4;
    private readonly ICommand[] commands = new ICommand[4];
    private readonly bool[] state = new bool[numOfButtons];

    public Remote()
    {

    }

    public void SetCommandButton(ICommand command, int index)
    {
        commands[index] = command;
    }

    public void PressButton(int index)
    {
        if(index  > numOfButtons)
        {
            Console.WriteLine("Outside of buttons");
            return;
        }
        if (index < 0)
        {
            Console.WriteLine("Can not be 0");
        }

        var cmd = commands[index];
        bool cmdState = state[index];
        if (!cmdState)
        {
            cmd.Execute();
            state[index] = !cmdState;
        }
        else
        {
            cmd.Undo();
            state[index] = !cmdState;
        }
    }
}

public class Command
{
    public static void Invoke()
    {
        Remote remote = new Remote();
        Light light = new Light();
        Fan fan = new Fan();

        ICommand lightCommand = new LightCommand(light);
        ICommand fanCommand = new FanCommand(fan);

        remote.SetCommandButton(lightCommand, 0);
        remote.SetCommandButton(fanCommand, 1);

        remote.PressButton(0);
        remote.PressButton(0);
    }
}
