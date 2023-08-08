namespace XO.Game.CodeBase
{
  public class PlayersController
  {
    private readonly Game _game;
    
    private  IPlayer _nextPlayer;
    private  IPlayer _activePlayer;

    public PlayersController(Game game)
    {
      _game = game;
      
      _activePlayer = new RealPlayer(_game, Symbol.X);
      _nextPlayer = new RealPlayer(_game, Symbol.O);
      
      _activePlayer.OnMadeMove += Move;
      _activePlayer.Enter();
    }

    private void Move(Cell cell)
    {
      if (!_game.TryMove(_activePlayer, cell))
        return;
      
      _activePlayer.OnMadeMove -= Move;
      (_activePlayer, _nextPlayer) = (_nextPlayer, _activePlayer);

      _activePlayer.OnMadeMove += Move;
      _activePlayer.Enter();
    }
  }
}