using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using XO.Extensions;
using XO.Modules.States;
using Zenject;

namespace XO.Gameplay.CodeBase.Behaviours
{
  public class CellView : MonoBehaviour, IPointerClickHandler
  {
    public Sprite X;
    public Sprite O;

    private Image _view;
    private Cell _cell;
    private PlayersController _playersController;
    private GameLoop _gameLoop;
    
    [Inject]
    public void SetDependency(GameLoop gameLoop) => 
      _gameLoop = gameLoop;

    public void Start()
    {
      _view = GetComponent<Image>();

      if (_gameLoop.IsInitialized)
        _gameLoop.Game.UpdateView += TryUpdateView;
      else
        _gameLoop.OnInitialize += () => { _gameLoop.Game.UpdateView += TryUpdateView; };
    }

    public void Initialize(Cell cell)
    {
      _cell = cell;
    }

    public void OnPointerClick(PointerEventData eventData) => 
      _gameLoop.PlayersController.Move(_cell);

    private void TryUpdateView(Cell cell, Symbol symbol)
    {
      if (_cell.Equals(cell)) 
        UpdateView(symbol);
    }

    private void UpdateView(Symbol symbol)
    {
      switch (symbol)
      {
        case Symbol.X:
          _view.sprite = X;
          _view.Alpha(1);
          break;
        case Symbol.O:
          _view.sprite = O;
          _view.Alpha(1);
          break;
        default:
          _view.sprite = null;
          _view.Alpha(0);
          break;
      }
    }
  }
}