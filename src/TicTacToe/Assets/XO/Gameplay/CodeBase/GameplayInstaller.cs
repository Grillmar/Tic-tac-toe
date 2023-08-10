using XO.Gameplay.CodeBase.Behaviours;
using XO.Gameplay.CodeBase.Player;
using Zenject;

namespace XO.Gameplay.CodeBase
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