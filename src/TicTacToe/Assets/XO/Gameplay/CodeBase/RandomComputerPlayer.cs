using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
      RandomMove();

    private async void RandomMove()
    {
      await Task.Delay(1000);

      IList<Cell> possibleMoves = _game.GetPossibleMoves();

      if (!possibleMoves.Any())
        return;

      OnMadeMove?.Invoke(possibleMoves.RandomElement());
    }
  }
}