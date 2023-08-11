using System;
using System.Collections.Generic;

namespace XO.Gameplay.CodeBase
{
  public class Board
  {
    public const int Size = 3;
    
    private readonly Symbol?[,] _data;

    public Board() => 
      _data = new Symbol?[Size,Size];

    public Symbol? this[int row, int column]
    {
      get => GetSymbol(row, column);
      set => SetSymbol(row, column, value);
    }

    public List<(int row, int column)> GetEmptyCells()
    {
      var result = new List<(int row, int column)>();

      for (var row = 0; row < Size; row++)
      for (var column = 0; column < Size; column++)
        if (!_data[row, column].HasValue)
          result.Add((row, column));

      return result;
    }

    public Symbol?[,] GetCells()
    {
      var result = new Symbol?[Size,Size];

      for (var row = 0; row < Size; row++)
      for (var column = 0; column < Size; column++)
        result[row, column] = _data[row, column];

      return result;
    }

    private void SetSymbol(int row, int column, Symbol? value) => 
      _data[row, column] = value;

    private Symbol? GetSymbol(int row, int column) => 
      _data[row, column];


    public bool IsWin((int row, int column) cell, Symbol symbol) =>
      IsRowFilled(cell.row, symbol) ||
      IsColumnFilled(cell.column, symbol) ||
      IsDiagonalFilled(symbol);

    private bool IsColumnFilled(int column, Symbol symbol)
    {
      for (var row = 0; row < Size; row++)
        if (_data[row, column] != symbol)
          return false;

      return true;
    }

    private bool IsRowFilled(int row, Symbol symbol)
    {
      for (var column = 0; column < Size; column++)
        if (_data[row, column] != symbol)
          return false;

      return true;
    }

    private bool IsDiagonalFilled(Symbol symbol)
    {
      return CalculateDiagonal(MainDiagonal()) || CalculateDiagonal(InvertDiagonal());

      Func<int, int> MainDiagonal() => i => i;
      Func<int, int> InvertDiagonal() => i => Size - i - 1;
      
      bool CalculateDiagonal(Func<int, int> diagonal)
      {
        for (var i = 0; i < Size; i++)
          if (_data[i, diagonal(i)] != symbol)
            return false;

        return true;
      }
    }
  }
}