namespace TicTacToe.Model;

public class Player
{
    private readonly string id;
    private readonly string name;
    private readonly Symbol symbol;

    public Player(string id, string name, Symbol symbol)
    {

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
