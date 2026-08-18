using TicTacToe.Model;

namespace TicTacToe.Strategy;

public interface IWinningStrategy
{
    bool IsGameWin(Board board);
}
