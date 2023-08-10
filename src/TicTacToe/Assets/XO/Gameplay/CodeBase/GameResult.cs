using System;
using XO.Gameplay.CodeBase.Timer;
using XO.Window;
using XO.Window.Windows;
using Zenject;

namespace XO.Gameplay.CodeBase
{
  public class GameResult : IInitializable, IDisposable
  {
    private readonly Game _game;
    private readonly IWindowService _windowService;
    private readonly CoroutineTimer _timer;
    private const int Time = 6;
    private GameState _activePlayer = GameState.FirstPlayerMove;

    public GameResult(Game game, IWindowService windowService, CoroutineTimer timer)
    {
      _game = game;
      _windowService = windowService;
      _timer = timer;
    }

    public void Initialize()
    {
      _game.UpdateState += CheckEndGame;
      _timer.OnFinish += GameOver;
      
      _timer.StartTimer(Time, 1);
    }

    public void Dispose()
    {
      _timer.OnFinish -= GameOver;
      _game.UpdateState -= CheckEndGame;
    }

    private void GameOver()
    {
      _windowService.Open(WindowTypeId.Lose, _activePlayer == GameState.FirstPlayerMove ? "X": "O");
      _timer.StopTimer();
      Dispose();
    }

    private void CheckEndGame(GameState state)
    {
      _activePlayer = state;
      
      switch (state)
      {
        case GameState.FirstPlayerVictory:
          _timer.StopTimer();
          _windowService.Open(WindowTypeId.Win, "X");
          _game.UpdateState -= CheckEndGame;
          break;
        case GameState.SecondPlayerVictory:
          _timer.StopTimer();
          _windowService.Open(WindowTypeId.Win, "O");
          _game.UpdateState -= CheckEndGame;
          break;
        case GameState.Draw:
          _timer.StopTimer();
          _windowService.Open(WindowTypeId.Draw);
          _game.UpdateState -= CheckEndGame;
          break;
        default:
          _timer.StopTimer();
          _timer.StartTimer(Time,1);
          break;
      }
    }
  }
}