using System;

namespace XO.Game.CodeBase
{
  public interface IPlayer
  {
    event Action<Cell> OnMadeMove;
    Symbol Symbol { get; }

    void Enter();
  }
}