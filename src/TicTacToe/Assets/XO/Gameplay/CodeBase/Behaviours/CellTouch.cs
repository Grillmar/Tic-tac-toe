using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Zenject;

namespace XO.Gameplay.CodeBase.Behaviours
{
  public class CellTouch : MonoBehaviour, IPointerClickHandler
  {
    public UnityEvent OnProduce;

    private (int row, int column) _cell;
    private TouchHolder _touchHolder;

    [Inject]
    public void SetDependency(TouchHolder touchHolder) => 
      _touchHolder = touchHolder;

    public void Initialize((int row, int column) cell) => 
      _cell = cell;

    public void OnPointerClick(PointerEventData eventData)
    {
      OnProduce?.Invoke();
      _touchHolder.Touch(_cell);
    }
  }
}