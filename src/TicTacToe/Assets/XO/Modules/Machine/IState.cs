namespace XO.Modules.Machine
{
  public interface IState : IExitableState
  {
    void Enter();
  }
}