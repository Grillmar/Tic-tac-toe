using UnityEngine.Audio;
using XO.Gameplay.CodeBase;
using XO.Modules.AssetsManagement;
using XO.Modules.Curtain;
using XO.Modules.Loader;
using XO.Modules.Machine;
using XO.Modules.Progress;
using XO.Modules.States;
using XO.Modules.Window;
using XO.Modules.Window.Windows.Settings;
using Zenject;

namespace XO.Modules.Bootstrap
{
  public class BootstrapInstaller : MonoInstaller, IInitializable
  {
    public LoadingCurtain LoadingCurtain;
    public WindowsConfig WindowsConfig;
    public AudioMixer Mixer;
    public override void InstallBindings()
    {
      Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
      
      Container.Bind<GameData>().AsSingle();
      
      Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
      
      Container.BindInterfacesTo<ReadWriteProgress>().AsSingle();

      Container.BindInterfacesAndSelfTo<AudioController>().AsSingle().WithArguments(Mixer).NonLazy();;
      
      Container.Bind<ProgressData>().AsSingle();

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