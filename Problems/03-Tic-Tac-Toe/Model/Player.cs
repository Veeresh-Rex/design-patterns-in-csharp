namespace TicTacToe.Model;

public class Player
{
    private readonly string id;
    private readonly string name;
    private readonly Symbol symbol;

    public Player(string id, string name, Symbol symbol)
    {
        this.id = id;
        this.name = name;
        this.symbol = symbol;
    }

    public string GetId()
    {
        return id;
    }

    public string GetName()
    {
        return name;
    }

    public Symbol GetSymbol()
    {
        return symbol;
    }
}
