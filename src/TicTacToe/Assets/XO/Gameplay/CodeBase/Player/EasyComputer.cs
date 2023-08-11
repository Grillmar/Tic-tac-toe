using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XO.Extensions;

namespace XO.Gameplay.CodeBase.Player
{
  public class EasyComputer : IPlayer
  {
    public Symbol Symbol { get; private set; }
    
    private Game _game;
    
    public void Initialize(Game game, Symbol symbol)
    {
      _game = game;
      Symbol = symbol;
    }

    public void Enter() =>
      RandomMove();
    
    private async void RandomMove()
    {
      await Task.Delay(1000);

      IList<(int row, int column)> possibleMoves = _game.GetPossibleMoves();

      if (!possibleMoves.Any())
        return;
      _game.Move(this, possibleMoves.RandomElement());
    }
  }
}