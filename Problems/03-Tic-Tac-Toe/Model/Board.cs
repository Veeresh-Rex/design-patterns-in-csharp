namespace TicTacToe.Model;

public class Board
{
    private readonly List<List<Symbol>> grid;
    public Board(int size)
    {
        grid = Enumerable
            .Range(0, size)
            .Select(_ => Enumerable.Repeat(new Symbol(), size).ToList())
            .ToList();
    }

    public int GetSize()
    {
        return grid.Count;
    }

    public bool IsCellEmpty(int row, int column)
    {
        var cell = grid[row][column];
        return cell.IsDefault();
    }

    public bool IsAllCellFilled()
    {
        return grid.Any(e => e.Any(y => y.IsDefault()));
    }

    public Symbol GetCellValue(int row, int column)
    {
        return grid[row][column];
    }

    public void Display()
    {
        foreach (var row in grid)
        {
            Console.WriteLine(string.Join(" ",row.Select(e => e.GetMark())));
        }
    }

    public void MarkCell(int row, int column, Symbol symbol)
    {
        var cell = grid[row][column];
        if (cell.IsDefault())
        {
            throw new InvalidOperationException("Cell is already marked");
        }

        grid[row][column] = symbol;
    }
}
