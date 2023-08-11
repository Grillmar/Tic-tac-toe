using System.Collections.Generic;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using XO.Gameplay.CodeBase;
using XO.Gameplay.CodeBase.Player;

namespace Tests.EditMode
{
  public class TicTacToeEditTests
  {
    [TestCaseSource(nameof(WinSequenceMoves))]
    public void CheckPlayerWin((GameState winner, List<(int row, int column)> steps) sequenceMove)
    {
      Game game = new Game();
      IPlayer activePlayer = Mock.Of<IPlayer>(x=> x.Symbol == Symbol.X);
      IPlayer nextPlayer = Mock.Of<IPlayer>(x=> x.Symbol == Symbol.O);

      foreach ((int row, int column) step in sequenceMove.steps)  
      {
        game.Move(activePlayer, step);

        (activePlayer, nextPlayer) = (nextPlayer, activePlayer);
      }

      game.State.Should().Be(sequenceMove.winner);
    }
    
    [TestCaseSource(nameof(LoseSequenceMoves ))]
    public void CheckPlayerLose((GameState loser, List<(int row, int column)> steps) sequenceMove)
    {
      Game game = new Game();
      IPlayer activePlayer = Mock.Of<IPlayer>(x=> x.Symbol == Symbol.X);
      IPlayer nextPlayer = Mock.Of<IPlayer>(x=> x.Symbol == Symbol.O);

      foreach ((int row, int column) step in sequenceMove.steps)  
      {
        game.Move(activePlayer, step);

        (activePlayer, nextPlayer) = (nextPlayer, activePlayer);
      }

      game.State.Should().NotBe(sequenceMove.loser);
    }
    
    [TestCaseSource(nameof(WinSequenceMoves))]
    public void CheckPlayerDraw((GameState draw, List<(int row, int column)> steps) sequenceMove)
    {
      Game game = new Game();
      IPlayer activePlayer = Mock.Of<IPlayer>(x=> x.Symbol == Symbol.X);
      IPlayer nextPlayer = Mock.Of<IPlayer>(x=> x.Symbol == Symbol.O);

      foreach ((int row, int column) step in sequenceMove.steps)  
      {
        game.Move(activePlayer, step);

        (activePlayer, nextPlayer) = (nextPlayer, activePlayer);
      }

      game.State.Should().Be(sequenceMove.draw);
    }

    [Test]
    public void CheckPlayerUndoState()
    {
      Game game = new Game();
      IPlayer activePlayer = Mock.Of<IPlayer>(x=> x.Symbol == Symbol.X);

      game.Move(activePlayer, (1,1));
      game.Undo();
      
      game.State.Should().Be(GameState.FirstPlayerMove);
    }
    
    [Test]
    public void CheckPlayerUndoStep()
    {
      Game game = new Game();
      IPlayer activePlayer = Mock.Of<IPlayer>(x=> x.Symbol == Symbol.X);
      (int row, int column) cell = (1,1);

      game.Move(activePlayer, cell);
      game.Undo();

      game.GetPossibleMoves().Should().Contain(cell);
    }

    public static IEnumerable<(GameState winner, List<(int row, int column)> steps)> WinSequenceMoves =>
      new[]
      {
        (GameState.FirstPlayerVictory, 
          new List<(int row, int column)>
          {
            (0, 0),
            (0, 1),
            (1,1),
            (0,2),
            (2,2)
          }),
        (GameState.SecondPlayerVictory, 
          new List<(int row, int column)>
          {
            (2,0),
            (0, 0),
            (0, 1),
            (1,1),
            (0,2),
            (2,2)
          }),
      };
    
    public static IEnumerable<(GameState loser, List<(int row, int column)> steps)> LoseSequenceMoves =>
      new[]
      {
        (GameState.SecondPlayerVictory, 
          new List<(int row, int column)>
          {
            (0, 0),
            (0, 1),
            (1,1),
            (0,2),
            (2,2)
          }),
        (GameState.FirstPlayerVictory, 
          new List<(int row, int column)>
          {
            (2,0),
            (0, 0),
            (0, 1),
            (1,1),
            (0,2),
            (2,2)
          }),
      };
    
    public static IEnumerable<(GameState loser, List<(int row, int column)> steps)> DrawSequenceMoves =>
      new[]
      {
        (GameState.Draw, 
          new List<(int row, int column)>
          {
            (0, 0),
            (0, 1),
            (0,2),
            (1,1),
            (1,0),
            (1,2),
            (2,2),
            (2,0),
            (2,1),
          }),
      };

  }
}