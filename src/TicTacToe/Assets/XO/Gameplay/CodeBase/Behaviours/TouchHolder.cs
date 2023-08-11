using System;

namespace XO.Gameplay.CodeBase.Behaviours
{
  public class TouchHolder
  {
    public event Action<(int row, int column)> OnTouchCell;

    public void Touch((int row, int column) cell) => 
      OnTouchCell?.Invoke(cell);
  }
}