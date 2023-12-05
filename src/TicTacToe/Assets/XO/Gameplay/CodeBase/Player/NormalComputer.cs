using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using XO.Modules.Extensions;

namespace XO.Gameplay.CodeBase.Player
{
  public class NormalComputer : IPlayer
  {
    public Symbol Symbol { get; private set; }

    private Game _game;

    private Symbol _otherSymbol;

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

      (int row, int column) bestMove = Random.value < 0.5f 
        ? possibleMoves.RandomElement() 
        : MinMax.FindBestMove(_game.GetCells(), Symbol);
      
      _game.Move(this,bestMove);
    }
  }
}