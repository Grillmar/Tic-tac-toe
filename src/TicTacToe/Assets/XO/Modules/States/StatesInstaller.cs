using XO.Modules.Machine;
using Zenject;

namespace XO.Modules.States
{
  public static class StatesInstaller
  {
    public static DiContainer BindStates(this DiContainer container)
    {
      container.Bind<BootstrapState>().AsSingle();
      container.Bind<MainState>().AsSingle();
      container.Bind<LoadMainState>().AsSingle();
      container.Bind<LoadGameState>().AsSingle();
      container.Bind<GameLoop>().AsSingle();
      
      return container;
    }
    
    public static DiContainer BindStateFactory(this DiContainer container)
    {
      container.Bind<IStateFactory>().To<StateFactory>().AsSingle();

      return container;
    }
    
    public static DiContainer BindStateMachine(this DiContainer container)
    {
      container.BindInterfacesAndSelfTo<StateMachine>().AsSingle();

      return container;
    }
  }
}