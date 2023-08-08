using System.Collections.Generic;
using UnityEngine;

namespace XO.Game.CodeBase
{
  public class Game
  {
    private GameState _state;
    private readonly Board _board;
    private readonly Stack<HistoryStep> _history;

    public Game()
    {
      _board = new Board();
      _history = new Stack<HistoryStep>();

      _state = GameState.FirstPlayerMove;
    }
    
    public IList<Cell> GetPossibleMoves() => 
      IsGameFinish() 
        ? new List<Cell>() 
        : _board.GetEmptyCells();

    public bool TryMove(IPlayer player, Cell cell)
    {
      if (IsCorrectPlayerMove(player))
      {
        Debug.Log("The turn belongs to another player.");
        return false;
      }

      if (IsFree(cell))
      {
        Debug.Log("The chosen cell is not empty.");
        return false;
      }

      if (IsGameFinish())
      {
        Debug.Log("The game was ended.");
        return false;
      }

      _history.Push(new HistoryStep(_state, player.Symbol, cell));

      _board[cell.Row, cell.Column] = player.Symbol;
      _state = GetState(cell, player.Symbol);

      return true;
    }

    public void Undo()
    {
      if (_history.Count == 0)
      {
        Debug.Log("The history is empty.");
      }

      (GameState previousState, _, Cell cell) = _history.Pop();

      _state = previousState;
      
      _board[cell.Row, cell.Column] = null;
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

    private bool IsCorrectPlayerMove(IPlayer player) =>
      (_state == GameState.FirstPlayerMove && player.Symbol != Symbol.X) ||
      (_state == GameState.SecondPlayerMove && player.Symbol != Symbol.O);

    private bool IsDraw() => 
      _board.GetEmptyCells().Count == 0;

    private bool IsFree(Cell cell) => 
      _board[cell.Row, cell.Column] != null;

    private bool IsGameFinish() =>
      _state == GameState.FirstPlayerVictory ||
      _state == GameState.SecondPlayerVictory ||
      _state == GameState.Draw;
  }
}