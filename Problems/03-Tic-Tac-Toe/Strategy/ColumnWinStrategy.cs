using TicTacToe.Model;

namespace TicTacToe.Strategy;

public class ColumnWinStrategy : IWinningStrategy
{
    public bool IsGameWin(Board board)
    {
        int size = board.GetSize();
        for (int col = 0; col < size; col++)
        {
            Symbol firstSymbol = board.GetCellValue(0, col);
            if (firstSymbol.IsDefault())
            {
                continue;
            }

            char firstMark = firstSymbol.GetMark();
            bool isAllColHaveSameSymbol = true;

            for (int row = 1; row < size; row++)
            {
                if (board.GetCellValue(row, col).GetMark() != firstMark)
                {
                    isAllColHaveSameSymbol = false;
                    break;
                }
            }

            if (isAllColHaveSameSymbol)
            {
                return true;
            }
        }

        return false;
    }
}
