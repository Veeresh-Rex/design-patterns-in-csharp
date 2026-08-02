using System;

namespace Csharp_design_patterns_lab.Structural.Decorator;

public interface ICharacter
{
    string GetPower();
}

public class Mario : ICharacter
{
    public string GetPower()
    {
        return "Mario";
    }
}

public abstract class PowerDecorator : ICharacter
{
    protected readonly ICharacter Character;

    protected PowerDecorator(ICharacter character)
    {
        Character = character ?? throw new ArgumentNullException(nameof(character));
    }

    public abstract string GetPower();
}

public class HeightUpPower : PowerDecorator
{
    public HeightUpPower(ICharacter character) : base(character)
    {
    }

    public override string GetPower()
    {
        return Character.GetPower() + " Height up";
    }
}

public class GunPower : PowerDecorator
{
    public GunPower(ICharacter character) : base(character)
    {
    }

    public override string GetPower()
    {
        return Character.GetPower() + " With Gun";
    }
}

public static class DecoratorDemo
{
    public static void Invoke()
    {
        Console.WriteLine("Decorator Pattern:");

        ICharacter mario = new Mario();
        Console.WriteLine(mario.GetPower());

        mario = new HeightUpPower(mario);
        Console.WriteLine(mario.GetPower());

        mario = new GunPower(mario);
        Console.WriteLine(mario.GetPower());

        Console.WriteLine();
    }
}
