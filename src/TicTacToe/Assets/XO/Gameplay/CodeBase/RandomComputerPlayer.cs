using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XO.Extensions;
using XO.Modules.States;
using Zenject;

namespace XO.Gameplay.CodeBase
{
  public class RandomComputerPlayer : IPlayer
  {
    public Symbol Symbol { get; private set; }
    
    private Game _game;
    private GameLoop _gameLoop;

    [Inject]
    public void SetDependency(GameLoop gameLoop) => 
      _gameLoop = gameLoop;
    
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

      IList<Cell> possibleMoves = _game.GetPossibleMoves();

      if (!possibleMoves.Any())
        return;

      _gameLoop.PlayersController.Move(possibleMoves.RandomElement());
    }
  }
}