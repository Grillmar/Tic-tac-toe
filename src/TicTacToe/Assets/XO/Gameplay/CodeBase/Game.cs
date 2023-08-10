using System;
using System.Collections.Generic;
using UnityEngine;
using XO.Gameplay.CodeBase.Player;

namespace XO.Gameplay.CodeBase
{
  public class Game
  {
    public event Action<GameState> UpdateState; 
    public event Action<Cell, Symbol?> UpdateView; 

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
    
    public Symbol?[,] GetCells() => 
      _board.GetCells();

    public void Move(IPlayer player, Cell cell)
    {
      if (IsCorrectPlayerMove(player))
      {
        Debug.Log("The turn belongs to another player.");
        return;
      }

      if (!IsEmpty(cell))
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
      
      UpdateState?.Invoke(_state);
      UpdateView?.Invoke(cell, player.Symbol);
    }

    public void Undo()
    {
      if (_history.Count == 0)
      {
        Debug.Log("The history is empty.");
        return;
      }

      (GameState previousState, _, Cell cell) = _history.Pop();

      _state = previousState;
      
      _board[cell.Row, cell.Column] = null;
      
      UpdateState?.Invoke(_state);
      UpdateView?.Invoke(cell, null);
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

    private bool IsEmpty(Cell cell) => 
      _board[cell.Row, cell.Column] == null;

    private bool IsGameFinish() =>
      _state == GameState.FirstPlayerVictory ||
      _state == GameState.SecondPlayerVictory ||
      _state == GameState.Draw;
  }
}