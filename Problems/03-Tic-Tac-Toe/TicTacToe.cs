using TicTacToe.Enums;
using TicTacToe.Model;
using TicTacToe.Observer;
using TicTacToe.Strategy;

namespace TicTacToe;

public class TicTacToe
{
    private static TicTacToe? instance;
    private static readonly object lockObj = new object();
    private Game? game;

    private TicTacToe()
    {

    }

    public static TicTacToe GetInstance()
    {
        if (instance == null)
        {
            lock (lockObj)
            {
                if (instance == null)
                {
                    instance = new TicTacToe();
                }
            }
        }
        return instance;
    }

    public Game CreateGame(List<Player> players, int boardSize = 3)
    {
        game = new Game(boardSize);
        foreach (var player in players)
        {
            game.AddPlayers(player);
        }

        game.AddObserver(new NotificationObserver());

        game.SetWinningStrategies(new ColumnWinStrategy());
        game.SetWinningStrategies(new RowWinStrategy());
        game.SetWinningStrategies(new DiagonalWinStrategy());

        return game;
    }

    public void MakeMove(int row, int column)
    {
        if (game == null)
        {
            Console.WriteLine("No active game. Please create a game first.");
            return;
        }

        if (game.GetGameStatus() != GameStatus.InProgress)
        {
            Console.WriteLine("Game has already ended. Cannot make more moves.");
            return;
        }

        game.AddMove(row, column);
        DisplayBoard();

        if (game.IsWinner())
        {
            var player = game.GetLatestMovePlayer();
            Console.WriteLine($"Player {player.GetName()} won the game!");
            game.UpdateStatus(GameStatus.WinEnd);
            return;
        }

        if (game.IsGameDraw())
        {
            Console.WriteLine("Game draw!");
            game.UpdateStatus(GameStatus.DrawEnd);
            return;
        }
    }

    public void DisplayBoard()
    {
        if (game == null)
        {
            Console.WriteLine("No active game board to display.");
            return;
        }
        game.GetBoard().Display();
    }
}
