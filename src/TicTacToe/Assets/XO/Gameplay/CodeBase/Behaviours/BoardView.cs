using System;
using System.Collections.Generic;
using UnityEngine;
using XO.Modules.States;
using XO.Window;
using XO.Window.Windows;
using Zenject;

namespace XO.Gameplay.CodeBase.Behaviours
{
  public class BoardView : MonoBehaviour
  {
    public List<CellView> CellViews;

    private GameLoop _gameLoop;
    private IWindowService _windowService;

    [Inject]
    public void SetDependency(GameLoop gameLoop, IWindowService windowService)
    {
      _gameLoop = gameLoop;
      _windowService = windowService;
    }

    private void Start()
    {
      InitializeCells();

      _gameLoop.OnInitialize += SubscribeOnInitialize;
    }

    private void OnDestroy() => 
      _gameLoop.OnInitialize -= SubscribeOnInitialize;

    private void SubscribeOnInitialize() => 
      _gameLoop.Game.UpdateState += CheckEndGame;

    private void CheckEndGame(GameState state)
    {

      switch (state)
      {
        case GameState.FirstPlayerVictory:
          _windowService.Open(WindowTypeId.Win, "X");
          _gameLoop.Game.UpdateState -= CheckEndGame;
          break;
        case GameState.SecondPlayerVictory:
          _windowService.Open(WindowTypeId.Win, "O");
          _gameLoop.Game.UpdateState -= CheckEndGame;
          break;
        case GameState.Draw:
          _windowService.Open(WindowTypeId.Draw);
          _gameLoop.Game.UpdateState -= CheckEndGame;
          break;
      }
    }

    private void InitializeCells()
    {
      var index = 0;
      for (var row = 0; row < Board.Size; row++)
      for (var column = 0; column < Board.Size; column++)
        CellViews[index++].Initialize(new Cell(row, column));
    }
  }
}