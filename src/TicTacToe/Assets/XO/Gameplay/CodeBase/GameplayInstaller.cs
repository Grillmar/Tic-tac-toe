using XO.Gameplay.CodeBase;
using XO.Gameplay.CodeBase.Behaviours;
using Zenject;

namespace XO.Bootstrap
{
  public class GameplayInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container.Bind<Game>().AsSingle();
      Container.Bind<PlayersController>().AsSingle();
      Container.BindInterfacesAndSelfTo<GameResult>().AsSingle();
    }
  }
}