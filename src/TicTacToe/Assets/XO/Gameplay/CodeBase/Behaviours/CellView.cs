using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using XO.Extensions;
using XO.Modules.States;
using Zenject;

namespace XO.Gameplay.CodeBase.Behaviours
{
  public class CellView : MonoBehaviour, IPointerClickHandler, IEquatable<Cell>
  {
    public Sprite X;
    public Sprite O;
    public Image View { get; private set; }

    private Cell _cell;
    private PlayersController _playersController;
    private GameLoop _gameLoop;
    
    [Inject]
    public void SetDependency(GameLoop gameLoop) => 
      _gameLoop = gameLoop;

    public void Initialize(Cell cell) => 
      _cell = cell;

    public void Start()
    {
      View = GetComponent<Image>();

      if (_gameLoop.IsInitialized)
        _gameLoop.Game.UpdateView += TryUpdateView;
      else
        _gameLoop.OnInitialize += () => { _gameLoop.Game.UpdateView += TryUpdateView; };
    }

    public bool Equals(Cell other) => 
      _cell.Column == other?.Column && _cell.Row == other.Row;

    public void OnPointerClick(PointerEventData eventData) => 
      _gameLoop.PlayersController.Move(_cell);

    private void TryUpdateView(Cell cell, Symbol? symbol)
    {
      if (_cell.Equals(cell)) 
        UpdateView(symbol);
    }

    private void UpdateView(Symbol? symbol)
    {
      switch (symbol)
      {
        case Symbol.X:
          View.sprite = X;
          View.Alpha(1);
          break;
        case Symbol.O:
          View.sprite = O;
          View.Alpha(1);
          break;
        default:
          View.sprite = null;
          View.Alpha(0);
          break;
      }
    }
  }
}