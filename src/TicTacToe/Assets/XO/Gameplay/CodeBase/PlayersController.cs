using System;

namespace XO.Gameplay.CodeBase
{
  public class PlayersController
  {
    private readonly Game _game;
    
    private  IPlayer _nextPlayer;
    private  IPlayer _activePlayer;

    public PlayersController(Game game)
    {
      _game = game;
      _game.UpdateState += ChangePlayer;
      
      _activePlayer = new RealPlayer(_game, Symbol.X);
      _nextPlayer = new RealPlayer(_game, Symbol.O);
      
      _activePlayer.OnMadeMove += Move;
      _activePlayer.Enter();
    }

    private void ChangePlayer(GameState state)
    {
      switch (state)
      {
        case GameState.FirstPlayerMove:
        case GameState.SecondPlayerMove:
          RollPlayer();
          break;
      }
    }

    public void Move(Cell cell) => 
      _game.TryMove(_activePlayer, cell);

    private void RollPlayer()
    {
      _activePlayer.OnMadeMove -= Move;
      (_activePlayer, _nextPlayer) = (_nextPlayer, _activePlayer);

      _activePlayer.OnMadeMove += Move;
      _activePlayer.Enter();
    }
  }
}