using System;

namespace XO.Gameplay.CodeBase
{
  public class Cell : IEquatable<Cell>
  {
    public readonly int Row;
    public readonly int Column;

    public Cell(int row, int column)
    {
      Row = row;
      Column = column;
    }

    public bool Equals(Cell cell) => 
      Row == cell?.Row && Column == cell.Column;
  }
}