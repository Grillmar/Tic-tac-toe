﻿using System;

namespace XO.Gameplay.CodeBase.Player
{
  public class MinMax
  {
    public static (int row, int column) FindBestMove(Symbol?[,] board, Symbol mySymbol)
    {
      int boardSize = board.GetLength(0);
      var bestScore = int.MinValue;

      (int row, int column) bestMove = (-1, -1);

      for (var i = 0; i < boardSize; i++)
      for (var j = 0; j < boardSize; j++)
        if (board[i, j] == null)
        {
          board[i, j] = mySymbol;
          int score = Minimax(board, 0, false, mySymbol);
          board[i, j] = null;

          if (score > bestScore)
          {
            bestScore = score;
            bestMove = (i, j);
          }
        }

      return bestMove;
    }

    private static int Minimax(Symbol?[,] board, int depth, bool isMaximizing, Symbol mySymbol)
    {
      int boardSize = board.GetLength(0);

      Symbol otherSymbol = GetOtherSymbol(mySymbol);
      Symbol? winner = CheckWinner(board, boardSize, mySymbol, otherSymbol);

      if (winner == mySymbol)
        return 10 - depth;

      if (winner == otherSymbol)
        return depth - 10;

      if (!IsEmptyCellLeft(board, boardSize))
        return 0;

      if (isMaximizing)
      {
        var bestScore = int.MinValue;
        for (var i = 0; i < boardSize; i++)
        for (var j = 0; j < boardSize; j++)
          if (board[i, j] == null)
          {
            board[i, j] = mySymbol;
            int score = Minimax(board, depth + 1, false, mySymbol);
            board[i, j] = null;
            bestScore = Math.Max(bestScore, score);
          }

        return bestScore;
      }
      else
      {
        var bestScore = int.MaxValue;
        for (var i = 0; i < boardSize; i++)
        for (var j = 0; j < boardSize; j++)
          if (board[i, j] == null)
          {
            board[i, j] = otherSymbol;
            int score = Minimax(board, depth + 1, true, mySymbol);
            board[i, j] = null;
            bestScore = Math.Min(bestScore, score);
          }

        return bestScore;
      }
    }

    private static Symbol? CheckWinner(Symbol?[,] board, int boardSize, Symbol mySymbol, Symbol otherSymbol)
    {
      for (var i = 0; i < boardSize; i++)
      {
        if (board[i, 0] == mySymbol && board[i, 1] == mySymbol && board[i, 2] == mySymbol)
          return mySymbol;
        if (board[i, 0] == otherSymbol && board[i, 1] == otherSymbol && board[i, 2] == otherSymbol)
          return otherSymbol;
      }

      for (var j = 0; j < boardSize; j++)
      {
        if (board[0, j] == mySymbol && board[1, j] == mySymbol && board[2, j] == mySymbol)
          return mySymbol;
        if (board[0, j] == otherSymbol && board[1, j] == otherSymbol && board[2, j] == otherSymbol)
          return otherSymbol;
      }

      if (board[0, 0] == mySymbol && board[1, 1] == mySymbol && board[2, 2] == mySymbol)
        return mySymbol;
      if (board[0, 0] == otherSymbol && board[1, 1] == otherSymbol && board[2, 2] == otherSymbol)
        return otherSymbol;

      if (board[0, 2] == mySymbol && board[1, 1] == mySymbol && board[2, 0] == mySymbol)
        return mySymbol;
      if (board[0, 2] == otherSymbol && board[1, 1] == otherSymbol && board[2, 0] == otherSymbol)
        return otherSymbol;

      return null;
    }

    private static bool IsEmptyCellLeft(Symbol?[,] board, int boardSize)
    {
      for (var i = 0; i < boardSize; i++)
      for (var j = 0; j < boardSize; j++)
        if (board[i, j] == null)
          return true;

      return false;
    }

    private static Symbol GetOtherSymbol(Symbol symbol) =>
      symbol == Symbol.X
        ? Symbol.O
        : Symbol.X;
  }
}