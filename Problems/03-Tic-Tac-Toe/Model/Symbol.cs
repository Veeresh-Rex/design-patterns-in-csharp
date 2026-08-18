namespace TicTacToe.Model;

public class Symbol
{
    private readonly char mark;

    public Symbol(char ch = '-')
    {
        mark = ch;
    }

    public char GetMark()
    {
        return mark;
    }

    public bool IsDefault()
    {
        return mark == '-';
    }
}
