using System.Collections.Generic;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using XO.Gameplay.CodeBase;
using XO.Gameplay.CodeBase.Player;

namespace Tests
{
  public class TicTacToeEditTests
  {
    [TestCaseSource(nameof(WinSequenceMoves))]
    public void CheckPlayerWin((GameState winner, List<Cell> steps) sequenceMove)
    {
      Game game = new Game();
      IPlayer activePlayer = Mock.Of<IPlayer>(x=> x.Symbol == Symbol.X);
      IPlayer nextPlayer = Mock.Of<IPlayer>(x=> x.Symbol == Symbol.O);

      foreach (Cell step in sequenceMove.steps)  
      {
        game.Move(activePlayer, step);

        (activePlayer, nextPlayer) = (nextPlayer, activePlayer);
      }

      game.State.Should().Be(sequenceMove.winner);
    }
    
    [TestCaseSource(nameof(LoseSequenceMoves ))]
    public void CheckPlayerLose((GameState loser, List<Cell> steps) sequenceMove)
    {
      Game game = new Game();
      IPlayer activePlayer = Mock.Of<IPlayer>(x=> x.Symbol == Symbol.X);
      IPlayer nextPlayer = Mock.Of<IPlayer>(x=> x.Symbol == Symbol.O);

      foreach (Cell step in sequenceMove.steps)  
      {
        game.Move(activePlayer, step);

        (activePlayer, nextPlayer) = (nextPlayer, activePlayer);
      }

      game.State.Should().NotBe(sequenceMove.loser);
    }
    
    [TestCaseSource(nameof(WinSequenceMoves))]
    public void CheckPlayerDraw((GameState draw, List<Cell> steps) sequenceMove)
    {
      Game game = new Game();
      IPlayer activePlayer = Mock.Of<IPlayer>(x=> x.Symbol == Symbol.X);
      IPlayer nextPlayer = Mock.Of<IPlayer>(x=> x.Symbol == Symbol.O);

      foreach (Cell step in sequenceMove.steps)  
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

      game.Move(activePlayer, new Cell(1,1));
      game.Undo();
      
      game.State.Should().Be(GameState.FirstPlayerMove);
    }
    
    [Test]
    public void CheckPlayerUndoStep()
    {
      Game game = new Game();
      IPlayer activePlayer = Mock.Of<IPlayer>(x=> x.Symbol == Symbol.X);
      Cell cell = new Cell(1,1);

      game.Move(activePlayer, cell);
      game.Undo();

      game.GetPossibleMoves().Should().Contain(cell);
    }

    public static IEnumerable<(GameState winner, List<Cell> steps)> WinSequenceMoves =>
      new[]
      {
        (GameState.FirstPlayerVictory, 
          new List<Cell>
          {
            new Cell(0, 0),
            new Cell(0, 1),
            new Cell(1,1),
            new Cell(0,2),
            new Cell(2,2)
          }),
        (GameState.SecondPlayerVictory, 
          new List<Cell>
          {
            new Cell(2,0),
            new Cell(0, 0),
            new Cell(0, 1),
            new Cell(1,1),
            new Cell(0,2),
            new Cell(2,2)
          }),
      };
    
    public static IEnumerable<(GameState loser, List<Cell> steps)> LoseSequenceMoves =>
      new[]
      {
        (GameState.SecondPlayerVictory, 
          new List<Cell>
          {
            new Cell(0, 0),
            new Cell(0, 1),
            new Cell(1,1),
            new Cell(0,2),
            new Cell(2,2)
          }),
        (GameState.FirstPlayerVictory, 
          new List<Cell>
          {
            new Cell(2,0),
            new Cell(0, 0),
            new Cell(0, 1),
            new Cell(1,1),
            new Cell(0,2),
            new Cell(2,2)
          }),
      };
    
    public static IEnumerable<(GameState loser, List<Cell> steps)> DrawSequenceMoves =>
      new[]
      {
        (GameState.Draw, 
          new List<Cell>
          {
            new Cell(0, 0),
            new Cell(0, 1),
            new Cell(0,2),
            new Cell(1,1),
            new Cell(1,0),
            new Cell(1,2),
            new Cell(2,2),
            new Cell(2,0),
            new Cell(2,1),
          }),
      };

  }
}