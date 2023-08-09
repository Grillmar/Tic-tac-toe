using System;

namespace XO.Gameplay.CodeBase
{
  public interface IPlayer
  {
    event Action<Cell> OnMadeMove;
    Symbol Symbol { get; }

    void Enter();
  }
}