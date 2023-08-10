using XO.Gameplay.CodeBase.Player;
using Zenject;

namespace XO.Gameplay.CodeBase
{
  public class GameplayInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container.Bind<Game>().AsSingle();
      Container.Bind<IPlayerFactory>().To<PlayerFactory>().AsSingle();

      Container.Bind<RealPlayer>().AsTransient();
      Container.Bind<EasyComputer>().AsTransient();
      Container.Bind<HardComputer>().AsTransient();

      Container.BindInterfacesAndSelfTo<GameResult>().AsSingle();
      Container.Bind<PlayersController>().AsSingle().NonLazy();
    }
  }
}