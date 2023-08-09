using System;
using XO.Gameplay.CodeBase;
using XO.Modules.Machine;

namespace XO.Modules.States
{
  public class GameLoop : IState
  {
    public event Action OnInitialize;

    public Game Game { get; private set; }
    public PlayersController PlayersController { get; private set; }


    public void Enter()
    {
      Game = new Game();
      PlayersController = new PlayersController(Game);
      
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