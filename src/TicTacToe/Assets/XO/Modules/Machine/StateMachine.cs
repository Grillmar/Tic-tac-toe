using System;
using Zenject;

namespace XO.Modules.Machine
{
  public class StateMachine :  ITickable, IFixedTickable, IDisposable
  {
    private IStateInfo _currentStateInfo;
    
    private readonly IStateFactory _stateFactory;

    public StateMachine(IStateFactory stateFactory) => 
      _stateFactory = stateFactory;

    public void Enter<TState>() where TState : class, IState => 
      ChangeState<TState>().Enter();

    public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload> => 
      ChangeState<TState>().Enter(payload);
    
    public void Tick() =>
      _currentStateInfo?.Update();

    public void FixedTick() => 
      _currentStateInfo?.FixedUpdate();

    public void Dispose() => 
      _currentStateInfo?.Exit();

    private TState ChangeState<TState>() where TState : class, IExitableState
    {
      _currentStateInfo?.Exit();
      var state = _stateFactory.GetState<TState>();
      _currentStateInfo = new StateInfo<TState>(state);
      return state;
    }
  }
}