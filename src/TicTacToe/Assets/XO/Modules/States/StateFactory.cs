using System;
using System.Collections.Generic;
using XO.Modules.Machine;
using Zenject;

namespace XO.Modules.States
{
  internal class StateFactory : IFactory<Type, IExitableState>, IStateFactory
  {
    private readonly Dictionary<Type, Func<IExitableState>> _states;

    public StateFactory(DiContainer container) => 
      _states = RegisterStates(container);

    private Dictionary<Type, Func<IExitableState>> RegisterStates(DiContainer diContainer) =>
      new Dictionary<Type, Func<IExitableState>>()
      {
        [typeof(BootstrapState)] = diContainer.Resolve<BootstrapState>,
        [typeof(MainState)] = diContainer.Resolve<MainState>,
      };

    public TState GetState<TState>() where TState : class, IExitableState => 
      Create(typeof(TState)) as TState;

    public IExitableState Create(Type type)
    {
      if (!_states.TryGetValue(type, out Func<IExitableState> state))
        throw new Exception($"State for {type.Name} can't be get");

      return state();
    }
  }
}