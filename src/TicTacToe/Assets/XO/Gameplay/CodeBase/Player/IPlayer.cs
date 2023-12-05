namespace XO.Gameplay.CodeBase.Player
{
  public interface IPlayer
  {
    Symbol Symbol { get; }

    void Initialize(Game game, Symbol symbol);

    void Enter();
    void Move((int row, int column) cell);
  }
}