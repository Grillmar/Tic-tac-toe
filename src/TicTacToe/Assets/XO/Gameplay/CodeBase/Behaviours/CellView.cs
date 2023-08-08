using UnityEngine;
using UnityEngine.EventSystems;
using XO.Modules.States;
using Zenject;

namespace XO.Gameplay.CodeBase.Behaviours
{
  public class CellView : MonoBehaviour, IPointerClickHandler
  {
    private Cell _cell;
    private PlayersController _playersController;
    private GameLoop _gameLoop;

    [Inject]
    public void SetDependency(GameLoop gameLoop) => 
      _gameLoop = gameLoop;
    
    public void Initialize(Cell cell)
    {
      _cell = cell;
    }

    public void OnPointerClick(PointerEventData eventData) => 
      _gameLoop.PlayersController.Move(_cell);
  }
}