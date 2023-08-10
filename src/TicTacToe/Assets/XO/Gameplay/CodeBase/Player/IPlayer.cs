namespace XO.Gameplay.CodeBase.Player
{
  public interface IPlayer
  {
    Symbol Symbol { get; }

    void Initialize(Game game, Symbol symbol, PlayersController playersController);

    void Enter();
  }
}