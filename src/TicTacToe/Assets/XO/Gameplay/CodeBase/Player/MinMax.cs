using System;

namespace XO.Gameplay.CodeBase.Player
{
  public class MinMax
  {
    public static (int, int) FindBestMove(Symbol?[,] board, Symbol mySymbol, Symbol otherSymbol)
    {
      var bestScore = int.MinValue;
      (int, int) bestMove = (-1, -1);

      for (var row = 0; row < 3; row++)
      {
        for (var column = 0; column < 3; column++)
        {
          if (board[row, column] == null)
          {
            board[row, column] = otherSymbol;
            int score = MiniMax(board, false, mySymbol, otherSymbol, int.MinValue, int.MaxValue);
            board[row, column] = null;

            if (score > bestScore)
            {
              bestScore = score;
              bestMove = (row, column);
            }
          }
        }
      }

      return bestMove;
    }

    private static bool IsWin(Symbol?[,] board, Symbol symbol)
    {
      for (var i = 0; i < 3; i++)
      {
        if (board[i, 0] == symbol && board[i, 1] == symbol && board[i, 2] == symbol)
          return true;

        if (board[0, i] == symbol && board[1, i] == symbol && board[2, i] == symbol)
          return true;
      }

      if (board[0, 0] == symbol && board[1, 1] == symbol && board[2, 2] == symbol)
        return true;

      if (board[0, 2] == symbol && board[1, 1] == symbol && board[2, 0] == symbol)
        return true;

      return false;
    }

    private static bool IsBoardFull(Symbol?[,] board)
    {
      for (var row = 0; row < 3; row++)
      {
        for (var column = 0; column < 3; column++)
        {
          if (board[row, column] == null)
            return false;
        }
      }
      return true;
    }

    private static int MiniMax(Symbol?[,] board, bool isMaximizing, Symbol playerSymbol, Symbol computerSymbol, int alpha, int beta)
    {
      if (IsWin(board, computerSymbol))
        return 10;
      if (IsWin(board, playerSymbol))
        return -10;
      if (IsBoardFull(board))
        return 0;

      if (isMaximizing)
      {
        var bestScore = int.MinValue;
        for (var row = 0; row < 3; row++)
        {
          for (var column = 0; column < 3; column++)
          {
            if (board[row, column] == null)
            {
              board[row, column] = computerSymbol;
              int score = MiniMax(board, false, playerSymbol, computerSymbol, alpha, beta);
              board[row, column] = null;
              bestScore = Math.Max(bestScore, score);
              alpha = Math.Max(alpha, bestScore);
              if (beta <= alpha)
                break;
            }
          }
        }

        return bestScore;
      }
      else
      {
        var bestScore = int.MaxValue;
        for (var row = 0; row < 3; row++)
        {
          for (var column = 0; column < 3; column++)
          {
            if (board[row, column] == null)
            {
              board[row, column] = playerSymbol;
              int score = MiniMax(board, true, playerSymbol, computerSymbol, alpha, beta);
              board[row, column] = null;
              bestScore = Math.Min(bestScore, score);
              beta = Math.Min(beta, bestScore);
              if (beta <= alpha)
                break;
            }
          }
        }

        return bestScore;
      }
    }
  }
}