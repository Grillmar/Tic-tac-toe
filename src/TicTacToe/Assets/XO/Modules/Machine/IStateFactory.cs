namespace XO.Modules.Machine
{
  public interface IStateFactory
  {
    TState GetState<TState>() where TState : class, IExitableState;
  }
}