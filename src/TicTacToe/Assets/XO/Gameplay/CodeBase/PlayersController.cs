using XO.Modules.Data;

namespace XO.Gameplay.CodeBase
{
  public class PlayersController
  {
    private readonly Game _game;
    
    private  IPlayer _nextPlayer;
    private  IPlayer _activePlayer;

    public PlayersController(Game game, GameData gameData)
    {
      _game = game;
      _game.UpdateState += ChangePlayer;

      _activePlayer = gameData.Players[0];
      _activePlayer.Initialize(_game, Symbol.X);
      
      _nextPlayer = gameData.Players[1];
      _nextPlayer.Initialize(_game, Symbol.O);
      
      _activePlayer.Enter();
    }

    private void ChangePlayer(GameState state) => 
      RollPlayer();

    public void Move(Cell cell) => 
      _game.Move(_activePlayer, cell);

    private void RollPlayer()
    {
      (_activePlayer, _nextPlayer) = (_nextPlayer, _activePlayer);
      _activePlayer.Enter();
    }
  }
}