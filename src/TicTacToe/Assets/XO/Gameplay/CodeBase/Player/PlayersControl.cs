namespace XO.Gameplay.CodeBase.Player
{
  public class PlayersControl
  {
    private readonly Game _game;

    private IPlayer _nextPlayer;
    private IPlayer _activePlayer;

    public PlayersControl(Game game, GameData gameData, IPlayerFactory playerFactory)
    {
      _game = game;
      _game.UpdateState += ChangePlayer;

      _activePlayer = playerFactory.Create(gameData.Players[0]);
      _activePlayer.Initialize(_game, Symbol.X);

      _nextPlayer = playerFactory.Create(gameData.Players[1]);
      _nextPlayer.Initialize(_game, Symbol.O);

      _activePlayer.Enter();
    }

    private void ChangePlayer(GameState state) =>
      RollPlayer();

    private void RollPlayer()
    {
      (_activePlayer, _nextPlayer) = (_nextPlayer, _activePlayer);
      _activePlayer.Enter();
    }

    public IPlayer GetActivePlayer() => 
      _activePlayer;
  }
}