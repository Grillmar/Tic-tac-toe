using System.Collections.Generic;
using XO.Gameplay.CodeBase.Player;

namespace XO.Gameplay.CodeBase
{
  public class PlayersController
  {
    private readonly Game _game;
    
    private  IPlayer _nextPlayer;
    private  IPlayer _activePlayer;

    private readonly Dictionary<PlayerType, IPlayer> _players = new Dictionary<PlayerType, IPlayer>()
    {
      [PlayerType.RealPlayer] = new RealPlayer(),
      [PlayerType.EasyComputer] = new EasyComputer(),
      [PlayerType.NormalComputer] = new EasyComputer(),
      [PlayerType.HardComputer] = new HardComputer(),
    };
    
    public PlayersController(Game game, PlayerData playerData)
    {
      _game = game;
      _game.UpdateState += ChangePlayer;

      _activePlayer = _players[playerData.Players[0]];
      _activePlayer.Initialize(_game, Symbol.X, this);
      
      _nextPlayer = _players[playerData.Players[1]];
      _nextPlayer.Initialize(_game, Symbol.O, this);
      
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