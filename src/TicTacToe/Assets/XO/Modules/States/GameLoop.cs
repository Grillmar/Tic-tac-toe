using XO.Gameplay.CodeBase;
using XO.Modules.Machine;

namespace XO.Modules.States
{
  public class GameLoop : IState
  {
    public Game Game { get; private set; }
    public PlayersController PlayersController { get; private set; }

    public void Enter()
    {
      Game = new Game();
      PlayersController = new PlayersController(Game);
    }

    public void Exit()
    {
    }
  }
}