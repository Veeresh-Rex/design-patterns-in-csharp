using TicTacToe.Enums;
using TicTacToe.Observer;
using TicTacToe.Strategy;

namespace TicTacToe.Model;

public class Game
{
    private readonly Board _board;
    private readonly LinkedList<Player> players = new LinkedList<Player>();
    private readonly List<IWinningStrategy> winningStrategies = new List<IWinningStrategy>();
    private readonly List<IObserver> observers = new List<IObserver>();
    private GameStatus gameStatus;

    public void Addobserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void NotifyObserver(string message)
    {
        foreach (var item in observers)
        {
            item.Update(message);
        }
    }

    public void AddPlayers(Player player)
    {
        players.AddLast(player);
    }

    public Board GetBoard()
    {
        return _board;
    }

    public void AddMove(int row, int column)
    {
        var player = players.First();
        if (_board.IsCellEmpty(row, column))
        {
            Console.WriteLine("This cell is already occupied, can't make a move");
            return;
        }

        _board.MarkCell(row, column, player.GetSymbol());
        players.RemoveFirst();

        NotifyObserver($"Player: {player.GetName()} made a move {player.GetSymbol().GetMark()} on place {row} {column}");

        players.AddLast(player);
    }

    public void SetWinningStrategies(IWinningStrategy winningStrategy)
    {
        winningStrategies.Add(winningStrategy);
    }

    public Player GetLatestMovePlayer()
    {
        return players.Last();
    }

    public GameStatus GetGameStatus()
    {
        return gameStatus;
    }

    public void UpdateStatus(GameStatus gameStatus)
    {
        this.gameStatus = gameStatus;
    }

    public bool IsGameDraw()
    {
        return _board.IsAllCellFilled();
    }

    public bool IsWinner()
    {
        foreach (var winStr in winningStrategies)
        {
            if (winStr.IsGameWin(_board))
            {
                return true;
            }
        }

        return false;
    }
}
