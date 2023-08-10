namespace XO.Gameplay.CodeBase.Player
{
  public interface IPlayerFactory
  {
    IPlayer Create(PlayerType type);
  }
}