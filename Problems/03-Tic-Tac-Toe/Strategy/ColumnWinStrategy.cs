using TicTacToe.Model;

namespace TicTacToe.Strategy;

public class ColumnWinStrategy : IWinningStrategy
{
    public bool IsGameWin(Board board)
    {
        for (int i = 0; i < board.GetSize(); i++) // Column
        {
            bool isAllRowHaveSameSymbol = false;
            char firstColumnMark = board.GetCellValue(i, 0).GetMark();

            for (int j = 1; j < board.GetSize(); j++) // Row
            {
                if (board.GetCellValue(j, i).GetMark() == firstColumnMark)
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
