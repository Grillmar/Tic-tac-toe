using XO.Modules.Loader;
using XO.Modules.Machine;
using XO.Modules.States;
using Zenject;

namespace XO.Bootstrap
{
  public class BootstrapInstaller : MonoInstaller, IInitializable
  {

    public override void InstallBindings()
    {
      Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
      
      Container
        .BindStateMachine()
        .BindStates()
        .BindStateFactory();


      Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this);
    }

    public void Initialize() =>
      Container.Resolve<StateMachine>().Enter<BootstrapState>();
  }
}