using XO.Modules.Machine;

namespace XO.Modules.States
{
  public class BootstrapState : IState
  {
    private const string Main = "Main";

    private readonly StateMachine _stateMachine;

    public BootstrapState(StateMachine stateMachine)
    {
      _stateMachine = stateMachine;
    }

    public void Enter()
    {
    }

    public void Exit()
    {
    }

  }
}