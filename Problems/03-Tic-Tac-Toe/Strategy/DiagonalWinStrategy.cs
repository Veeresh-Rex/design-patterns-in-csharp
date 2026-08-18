using TicTacToe.Model;

namespace TicTacToe.Strategy;

public class DiagonalWinStrategy : IWinningStrategy
{
    public bool IsGameWin(Board board)
    {
        bool isAllRowHaveSameSymbol = false;
        char firstRowMark = board.GetCellValue(0, 0).GetMark();

        for (int i = 1; i < board.GetSize(); i++)
        {

            if (board.GetCellValue(i, 0).GetMark() == firstRowMark)
            {
                isAllRowHaveSameSymbol = true;
            }
            else
            {
                isAllRowHaveSameSymbol = false;
                break;
            }
        }

        return isAllRowHaveSameSymbol;
    }
}
