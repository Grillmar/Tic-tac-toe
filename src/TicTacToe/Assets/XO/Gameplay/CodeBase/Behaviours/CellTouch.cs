using UnityEngine;
using UnityEngine.EventSystems;
using XO.Modules.Data;
using Zenject;

namespace XO.Gameplay.CodeBase.Behaviours
{
  public class CellTouch : MonoBehaviour, IPointerClickHandler
  {
    private Cell _cell;
    private PlayersController _playersController;
    
    [Inject]
    public void SetDependency(PlayersController gameData) => 
      _playersController = gameData;

    public void Initialize(Cell cell) => 
      _cell = cell;

    public void OnPointerClick(PointerEventData eventData) => 
      _playersController.Move(_cell);
    
  }
}