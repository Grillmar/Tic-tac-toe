using UnityEngine;
using UnityEngine.EventSystems;

namespace XO.Gameplay.CodeBase.Behaviours
{
  public class CellView : MonoBehaviour, IPointerClickHandler
  {
    private int _row;
    private int _column;

    public void Initialize(int row, int column)
    {
      _row = row;
      _column = column;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
      Debug.Log($"{_row} {_column}");
    }
  }
}