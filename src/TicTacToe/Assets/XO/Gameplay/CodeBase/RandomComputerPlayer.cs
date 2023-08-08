using System;
using XO.Extensions;

namespace XO.Gameplay.CodeBase
{
  public class RandomComputerPlayer : IPlayer
  {
    private readonly Game _game;
    public event Action<Cell> OnMadeMove;
    public Symbol Symbol { get; }

    public RandomComputerPlayer(Game game, Symbol symbol)
    {
      _game = game;
      Symbol = symbol;
    }

    public void Enter() => 
      OnMadeMove
        ?.Invoke(_game
          .GetPossibleMoves()
          .RandomElement());
  }
}