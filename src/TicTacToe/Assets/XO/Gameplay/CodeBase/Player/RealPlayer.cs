namespace XO.Gameplay.CodeBase.Player
{
  public class RealPlayer : IPlayer
  {
    public Symbol Symbol { get; private set; }

    public void Initialize(Game game, Symbol symbol, PlayersController playersController)
    {
      Symbol = symbol;
    }

    public void Enter()
    {
    }
  }
}