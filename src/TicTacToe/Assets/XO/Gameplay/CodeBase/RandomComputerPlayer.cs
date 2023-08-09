using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XO.Extensions;

namespace XO.Gameplay.CodeBase
{
  public class RandomComputerPlayer : IPlayer
  {
    public Symbol Symbol { get; private set; }
    
    private Game _game;
    private PlayersController _playersController;
    
    public void Initialize(Game game, Symbol symbol, PlayersController playersController)
    {
      _game = game;
      Symbol = symbol;
      _playersController = playersController;
    }

    public void Enter() =>
      RandomMove();

    public void Move(Cell cell) => 
      _playersController.Move(cell);

    private async void RandomMove()
    {
      await Task.Delay(1000);

      IList<Cell> possibleMoves = _game.GetPossibleMoves();

      if (!possibleMoves.Any())
        return;

      Move(possibleMoves.RandomElement());
    }
  }
}