using XO.Gameplay.CodeBase.Player;
using XO.Gameplay.CodeBase.Timer;
using Zenject;

namespace XO.Gameplay.CodeBase
{
  public class GameplayInstaller : MonoInstaller
  {
    public CoroutineTimer Timer;
    public override void InstallBindings()
    {
      Container.Bind<Game>().AsSingle();
      Container.Bind<IPlayerFactory>().To<PlayerFactory>().AsSingle();

      Container.Bind<CoroutineTimer>().FromInstance(Timer).AsSingle();
      
      Container.Bind<RealPlayer>().AsTransient();
      Container.Bind<EasyComputer>().AsTransient();
      Container.Bind<HardComputer>().AsTransient();

      Container.BindInterfacesAndSelfTo<GameResult>().AsSingle();
      Container.Bind<PlayersController>().AsSingle().NonLazy();
    }
  }
}