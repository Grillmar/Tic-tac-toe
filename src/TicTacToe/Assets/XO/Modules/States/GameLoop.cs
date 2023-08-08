using XO.Game.CodeBase;
using XO.Modules.Machine;

namespace XO.Modules.States
{
  public class GameLoop : IState
  {
    public void Enter()
    {
      Game.CodeBase.Game game = new Game.CodeBase.Game();
      PlayersController playersController = new PlayersController(game);
    }

    public void Exit()
    {
    }
  }
}