using System.Collections.Generic;
using UnityEngine;
using XO.Modules.States;
using Zenject;

namespace XO.Gameplay.CodeBase.Behaviours
{
  public class BoardView : MonoBehaviour
  {
    private GameLoop _gameLoop;

    public List<CellView> CellViews;

    [Inject]
    public void SetDependency(GameLoop gameLoop) => 
      _gameLoop = gameLoop;
    
    private void Awake()
    {
      int index = 0;
      for (var row = 0; row < Board.Size; row++)
      {
        for (var column = 0; column < Board.Size; column++)
        {
          CellViews[index++].Initialize(row, column);
        }
      }
    }
  }
}