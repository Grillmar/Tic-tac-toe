using System.Collections.Generic;
using UnityEngine;
using XO.Modules.States;

namespace XO.Gameplay.CodeBase.Behaviours
{
  public class BoardView : MonoBehaviour
  {
    private GameLoop _gameLoop;

    public List<CellView> CellViews;
    
    private void Start()
    {
      InitializeCells();
    }

    private void InitializeCells()
    {
      var index = 0;
      for (var row = 0; row < Board.Size; row++)
      for (var column = 0; column < Board.Size; column++)
        CellViews[index++].Initialize(new Cell(row, column));
    }
  }
}