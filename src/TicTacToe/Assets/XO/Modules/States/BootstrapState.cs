using XO.Modules.Machine;

namespace XO.Modules.States
{
  public class BootstrapState : IState
  {

    private readonly StateMachine _stateMachine;

    public BootstrapState(StateMachine stateMachine)
    {
      _stateMachine = stateMachine;
    }

    public void Enter()
    {
      _stateMachine.Enter<LoadMainState>();
    }

    public void Exit()
    {
    }
  }
}