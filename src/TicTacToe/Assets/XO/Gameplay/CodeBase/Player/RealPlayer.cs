using System.Collections.Generic;
using System.Linq;
using XO.Gameplay.CodeBase.Behaviours;

namespace XO.Gameplay.CodeBase.Player
{
  public class RealPlayer : IPlayer
  {
    public Symbol Symbol { get; private set; }
    
    private Game _game;
    private readonly TouchHolder _touchHolder;

    public RealPlayer(TouchHolder touchHolder) => 
      _touchHolder = touchHolder;

    public void Initialize(Game game, Symbol symbol)
    {
      _game = game;
      Symbol = symbol;
    }

    public void Enter() => 
      _touchHolder.OnTouchCell += Move;

    private void Move((int row, int column) cell)
    {
      IList<(int row, int column)> possibleMoves = _game.GetPossibleMoves();

      if (!possibleMoves.Any(x=>x.Equals(cell)))
        return;
      
      _game.Move(this, cell);
      
      _touchHolder.OnTouchCell -= Move;
    }
  }
}