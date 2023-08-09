using System;

namespace XO.Gameplay.CodeBase
{
  public class RealPlayer : IPlayer
  {
    private readonly Game _game;
    public event Action<Cell> OnMadeMove;
    public Symbol Symbol { get; }

    public RealPlayer(Game game, Symbol symbol)
    {
      _game = game;
      Symbol = symbol;
    }

    public void Enter()
    {
    }
  }
}