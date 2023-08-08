using System;
using System.Collections.Generic;
using UnityEngine;

namespace XO.Game.CodeBase
{
  public class Game
  {
    private GameState _state;
    private readonly Board _board;
    private readonly Stack<HistoryStep> _history;
    private readonly IPlayer _firstPlayer;
    private readonly IPlayer _secondPlayer;
    
    public void Move(IPlayer player, Cell cell)
    {
      if (_board[cell.Row, cell.Column] != null)
      {
        Debug.Log("The chosen cell is not empty.");
        return;
      }

      if (IsGameFinish())
      {
        Debug.Log("The game was ended.");
        return;
      }

      _history.Push(new HistoryStep(_state, player.Symbol, cell));

      _board[cell.Row, cell.Column] = player.Symbol;
      _state = GetState(cell, player.Symbol);
    }

    private GameState GetState(Cell cell, Symbol symbol)
    {
      if (_board.IsWin(cell, symbol))
        switch (symbol)
        {
          case Symbol.X:
            return GameState.FirstPlayerVictory;
          case Symbol.O:
            return GameState.SecondPlayerVictory;
        }

      if (IsDraw())
        return GameState.Draw;

      switch (symbol)
      {
        case Symbol.X:
          return GameState.SecondPlayerMove;
        case Symbol.O:
          return GameState.FirstPlayerMove;
      }
      
      return GameState.FirstPlayerMove;
    }

    private bool IsDraw() => 
      _board.GetEmptyCells().Count == 0;

    private bool IsGameFinish() =>
      _state == GameState.FirstPlayerVictory ||
      _state == GameState.SecondPlayerVictory ||
      _state == GameState.Draw;
  }
}