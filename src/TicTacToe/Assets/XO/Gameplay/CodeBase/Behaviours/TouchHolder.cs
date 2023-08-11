using System;

namespace XO.Gameplay.CodeBase.Behaviours
{
  public class TouchHolder
  {
    public event Action<Cell> OnTouchCell;

    public void Touch(Cell cell) => 
      OnTouchCell?.Invoke(cell);
  }
}