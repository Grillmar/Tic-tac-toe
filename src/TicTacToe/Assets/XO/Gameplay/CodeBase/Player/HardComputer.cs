using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XO.Gameplay.CodeBase.Player
{
  public class HardComputer : IPlayer
  {
    public Symbol Symbol { get; private set; }

    private Game _game;

    private Symbol _otherSymbol;

    public void Initialize(Game game, Symbol symbol)
    {
      _game = game;
      Symbol = symbol;
      _otherSymbol = symbol == Symbol.X ? Symbol.O : Symbol.X;
    }

    public void Enter() =>
      RandomMove();
    
    private async void RandomMove()
    {
      await Task.Delay(1000);

      IList<Cell> possibleMoves = _game.GetPossibleMoves();

      if (!possibleMoves.Any())
        return;

      (int row, int column) bestMove = MinMax.FindBestMove(_game.GetCells(), Symbol, _otherSymbol);
      
      _game.Move(this, new Cell(bestMove.row, bestMove.column));
    }
  }
}