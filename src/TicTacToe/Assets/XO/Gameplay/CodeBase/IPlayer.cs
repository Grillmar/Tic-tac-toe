namespace XO.Gameplay.CodeBase
{
  public interface IPlayer
  {
    Symbol Symbol { get; }

    void Initialize(Game game, Symbol symbol, PlayersController playersController);

    void Enter();

    void Move(Cell cell);
  }
}