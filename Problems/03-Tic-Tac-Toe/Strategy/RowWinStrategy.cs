using TicTacToe.Model;

namespace TicTacToe.Strategy;

public class RowWinStrategy : IWinningStrategy
{
    public bool IsGameWin(Board board)
    {
        int size = board.GetSize();
        for (int i = 0; i < size; i++)
        {
            Symbol firstSymbol = board.GetCellValue(i, 0);
            if (firstSymbol.IsDefault())
            {
                continue;
            }

            char firstMark = firstSymbol.GetMark();
            bool isAllRowHaveSameSymbol = true;

            for (int j = 1; j < size; j++)
            {
                if (board.GetCellValue(i, j).GetMark() != firstMark)
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
