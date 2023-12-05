using System.Collections.Generic;
using System.Linq;

namespace XO.Gameplay.CodeBase.Player
{
  public class RealPlayer : IPlayer
  {
    public Symbol Symbol { get; private set; }
    
    private Game _game;


    public void Initialize(Game game, Symbol symbol)
    {
      _game = game;
      Symbol = symbol;
    }

    public void Enter()
    {
    }

    public void Move((int row, int column) cell)
    {
      IList<(int row, int column)> possibleMoves = _game.GetPossibleMoves();

      if (!possibleMoves.Any(x=>x.Equals(cell)))
        return;
      
      _game.Move(this, cell);
    }
  }
}