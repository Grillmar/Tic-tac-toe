using System.Collections.Generic;
using System.Linq;
using XO.Gameplay.CodeBase.Behaviours;

namespace XO.Gameplay.CodeBase.Player
{
  public class RealPlayer : IPlayer
  {
    private Game _game;
    public Symbol Symbol { get; private set; }

    public void Initialize(Game game, Symbol symbol)
    {
      _game = game;
      Symbol = symbol;
    }

    public void Enter() => 
      CellTouch.OnTouchCell += Move;

    private void Move(Cell cell)
    {
      IList<Cell> possibleMoves = _game.GetPossibleMoves();

      if (!possibleMoves.Any(x=>x.Equals(cell)))
        return;
      
      _game.Move(this, cell);
      
      CellTouch.OnTouchCell -= Move;
    }
  }
}