using TicTacToe.Enums;
using TicTacToe.Model;
using TicTacToe.Observer;
using TicTacToe.Strategy;

namespace TicTacToel;

public class TicTacToe
{
    private static TicTacToe instance;
    private static object lockObj = new object();
    private Game game;
    private TicTacToe()
    {

    }

    public static TicTacToe GetInstance()
    {
        if(instance == null)
        {
            lock (lockObj)
            {
                if(instance == null)
                {
                    instance = new TicTacToe();
                }
            }
        }
        return instance;
    }

    public Game CreateGame(List<Player> players)
    {
        game = new Game();
        foreach (var player in players)
        {
            game.AddPlayers(player);
        }

        game.Addobserver(new NotificationObserver());

        game.SetWinningStrategies(new ColumnWinStrategy());
        game.SetWinningStrategies(new RowWinStrategy());
        game.SetWinningStrategies(new DiagonalWinStrategy());

        return game;
    }

    public void MakeMove(int row, int column)
    {
        game.AddMove(row, column);
        DisplayBoard();
        if (game.IsWinner())
        {
            var player = game.GetLatestMovePlayer();
            Console.WriteLine($"Player {player.GetName()} won the game");
            game.UpdateStatus(GameStatus.DrawEnd);
        }

        if (game.IsGameDraw())
        {
            Console.WriteLine("Game draw");
            game.UpdateStatus(GameStatus.DrawEnd);
        }
    }

    public void DisplayBoard()
    {
        game.GetBoard().Display();
    }
}
