using TicTacToe.Model;

namespace TicTacToe.Strategy;

public class DiagonalWinStrategy : IWinningStrategy
{
    public bool IsGameWin(Board board)
    {
        int size = board.GetSize();

        // Check main diagonal (top-left to bottom-right)
        Symbol mainFirstSymbol = board.GetCellValue(0, 0);
        if (!mainFirstSymbol.IsDefault())
        {
            char mainMark = mainFirstSymbol.GetMark();
            bool mainWin = true;
            for (int i = 1; i < size; i++)
            {
                if (board.GetCellValue(i, i).GetMark() != mainMark)
                {
                    mainWin = false;
                    break;
                }
            }
            if (mainWin) return true;
        }

        // Check anti-diagonal (top-right to bottom-left)
        Symbol antiFirstSymbol = board.GetCellValue(0, size - 1);
        if (!antiFirstSymbol.IsDefault())
        {
            char antiMark = antiFirstSymbol.GetMark();
            bool antiWin = true;
            for (int i = 1; i < size; i++)
            {
                if (board.GetCellValue(i, size - 1 - i).GetMark() != antiMark)
                {
                    antiWin = false;
                    break;
                }
            }
            if (antiWin) return true;
        }

        return false;
    }
}
