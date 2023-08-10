using System;
using XO.Window;
using XO.Window.Windows;
using Zenject;

namespace XO.Gameplay.CodeBase
{
  public class GameResult : IInitializable, IDisposable
  {
    private readonly Game _game;
    private readonly IWindowService _windowService;
    
    public GameResult(Game game, IWindowService windowService)
    {
      _game = game;
      _windowService = windowService;
    }

    public void Initialize() => 
      _game.UpdateState += CheckEndGame;

    public void Dispose() => 
      _game.UpdateState -= CheckEndGame;

    private void CheckEndGame(GameState state)
    {
      switch (state)
      {
        case GameState.FirstPlayerVictory:
          _windowService.Open(WindowTypeId.Win, "X");
          _game.UpdateState -= CheckEndGame;
          break;
        case GameState.SecondPlayerVictory:
          _windowService.Open(WindowTypeId.Win, "O");
          _game.UpdateState -= CheckEndGame;
          break;
        case GameState.Draw:
          _windowService.Open(WindowTypeId.Draw);
          _game.UpdateState -= CheckEndGame;
          break;
      }
    }
  }
}