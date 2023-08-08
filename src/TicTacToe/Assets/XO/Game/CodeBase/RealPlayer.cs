using System;
using XO.Extensions;

namespace XO.Game.CodeBase
{
  class RealPlayer : IPlayer
  {
    private readonly Game _game;
    public event Action<Cell> OnMadeMove;
    public Symbol Symbol { get; }

    public RealPlayer(Game game, Symbol symbol)
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