using TicTacToe.Model;

namespace TicTacToe.Strategy;

public class RowWinStrategy : IWinningStrategy
{
    public bool IsGameWin(Board board)
    {
        for (int i = 0; i < board.GetSize(); i++)
        {
            bool isAllRowHaveSameSymbol = false;
            char firstRowMark = board.GetCellValue(i, 0).GetMark();

            for (int j = 1; j < board.GetSize(); j++)
            {
                if (board.GetCellValue(i, j).GetMark() == firstRowMark)
                {
                    isAllRowHaveSameSymbol = true;
                }
                else
                {
                    isAllRowHaveSameSymbol = false;
                    break;
                }
            }
            if (isAllRowHaveSameSymbol)
            {
                return true;
            }
        }

        return false;
    }
}
