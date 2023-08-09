namespace XO.Gameplay.CodeBase
{
  public class RealPlayer : IPlayer
  {
    private PlayersController _playersController;
    public Symbol Symbol { get; private set; }

    public void Initialize(Game game, Symbol symbol, PlayersController playersController)
    {
      Symbol = symbol;
      _playersController = playersController;
    }

    public void Enter()
    {
    }

    public void Move(Cell cell) => 
      _playersController.Move(cell);
  }
}