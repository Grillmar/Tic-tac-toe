using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace XO.Gameplay.CodeBase.Behaviours
{
  public class CellTouch : MonoBehaviour, IPointerClickHandler
  {
    public static event Action<Cell> OnTouchCell; 
    private Cell _cell;

    public void Initialize(Cell cell) => 
      _cell = cell;

    public void OnPointerClick(PointerEventData eventData) => 
      OnTouchCell?.Invoke(_cell);
    
  }
}