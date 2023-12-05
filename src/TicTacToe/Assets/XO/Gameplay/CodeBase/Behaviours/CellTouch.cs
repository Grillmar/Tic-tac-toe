using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using XO.Gameplay.CodeBase.Player;
using Zenject;

namespace XO.Gameplay.CodeBase.Behaviours
{
  public class CellTouch : MonoBehaviour, IPointerClickHandler
  {
    public UnityEvent OnProduce;

    private (int row, int column) _cell;
    
    private PlayersControl _playersControl;

    [Inject]
    public void SetDependency(PlayersControl playersControl) => 
      _playersControl = playersControl;

    public void Initialize((int row, int column) cell) => 
      _cell = cell;

    public void OnPointerClick(PointerEventData eventData)
    {
      OnProduce?.Invoke();
      _playersControl.GetActivePlayer().Move(_cell);
    }
  }
}