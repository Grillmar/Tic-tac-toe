using System;

namespace XO.Modules.Machine
{
  public class StateInfo<TState> : AbstractStateInfo where TState : class, IExitableState
  {
    public override Type StateType { get; }

    public StateInfo(TState state)
    {
      StateType = typeof(TState);
      Initialize(state);
    }
  }
}