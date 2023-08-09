using XO.Modules.Curtain;
using XO.Modules.Data;
using XO.Modules.Loader;
using XO.Modules.Machine;
using XO.Modules.States;
using XO.Window;
using Zenject;

namespace XO.Bootstrap
{
  public class BootstrapInstaller : MonoInstaller, IInitializable
  {
    public LoadingCurtain LoadingCurtain;
    public WindowsConfig WindowsConfig;
    public override void InstallBindings()
    {
      Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
      Container.Bind<GameData>().To<GameData>().AsSingle();
      
      Container
        .BindStateMachine()
        .BindStates()
        .BindStateFactory();

      Container
        .BindWindowConfig(WindowsConfig)
        .BindWindowProvider();
      
      Container.Bind<LoadingCurtain>()
        .FromComponentInNewPrefab(LoadingCurtain)
        .AsSingle()
        .NonLazy();

      Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this);
    }

    public void Initialize() =>
      Container.Resolve<StateMachine>().Enter<BootstrapState>();
  }
}