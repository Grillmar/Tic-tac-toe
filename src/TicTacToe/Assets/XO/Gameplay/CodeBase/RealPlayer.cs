namespace XO.Gameplay.CodeBase
{
  public class RealPlayer : IPlayer
  {
    private Game _game;

    public Symbol Symbol { get; private set; }

    public void Initialize(Game game, Symbol symbol)
    {
      _game = game;
      Symbol = symbol;
    }

    public void Enter()
    {
    }
  }
}