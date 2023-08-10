using Zenject;

namespace XO.Gameplay.CodeBase.Player
{
  public class PlayerFactory : IPlayerFactory
  {
    private readonly DiContainer _container;

    public PlayerFactory(DiContainer container)
    {
      _container = container;
    }
    
    public IPlayer Create(PlayerType type)
    {
      switch (type)
      {
        case PlayerType.EasyComputer:
          return _container.Resolve<EasyComputer>();
        case PlayerType.NormalComputer:
          return _container.Resolve<EasyComputer>();
        case PlayerType.HardComputer:
          return _container.Resolve<HardComputer>();
        case PlayerType.RealPlayer:
          return _container.Resolve<RealPlayer>();
        default:
          return _container.Resolve<RealPlayer>();
      }
    }
  }
}