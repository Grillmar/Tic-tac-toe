using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace XO.Gameplay.CodeBase.Behaviours
{
  public class BoardView : MonoBehaviour
  {
    public Sprite X;
    public Sprite O;
    
    public List<CellView> CellViews;
    public List<CellTouch> CellTouches;
    
    private readonly Dictionary<(int row, int column), CellView> _cellViews = new Dictionary<(int row, int column), CellView>();
    private Game _game;

    [Inject]
    public void SetDependency(Game game) => 
      _game = game;

    private void Start()
    {
      InitializeCells();
      _game.UpdateView += TryUpdateView;
    }

    private void OnDestroy()
    {
      _game.UpdateView -= TryUpdateView;
    }

    private void TryUpdateView(Cell cell, Symbol? symbol) => 
      UpdateView(_cellViews[(cell.Row, cell.Column)], symbol);

    private void UpdateView(CellView view, Symbol? symbol)
    {
      switch (symbol)
      {
        case Symbol.X:
          view.UpdateSprite(X, 1);
          break;
        case Symbol.O:
          view.UpdateSprite(O, 1);
          break;
        default:
          view.UpdateSprite(null, 0);
          break;
      }
    }

    private void InitializeCells()
    {
      var index = 0;
      for (var row = 0; row < Board.Size; row++)
      for (var column = 0; column < Board.Size; column++)
      {
        var cell = new Cell(row, column);
        var cellView = CellViews[index];
        CellTouches[index].Initialize(cell);
        _cellViews.Add((cell.Row, cell.Column),cellView);
        index++;
      }
    }
  }
}