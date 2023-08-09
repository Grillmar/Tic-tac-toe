using System;
using XO.Gameplay.CodeBase;
using XO.Modules.Data;
using XO.Modules.Machine;

namespace XO.Modules.States
{
  public class GameLoop : IState
  {
    private readonly GameData _gameData;
    public event Action OnInitialize;

    public Game Game { get; private set; }
    public PlayersController PlayersController { get; private set; }

    public GameLoop(GameData gameData)
    {
      _gameData = gameData;
    }
    
    public void Enter()
    {
      Game = new Game();
      PlayersController = new PlayersController(Game, _gameData);
      
      OnInitialize?.Invoke();
    }

    public void Exit()
    {
      Game = null;
      PlayersController = null;
      OnInitialize = null;
    }
  }
}