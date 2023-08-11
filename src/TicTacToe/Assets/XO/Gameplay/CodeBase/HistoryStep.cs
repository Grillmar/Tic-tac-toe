namespace XO.Gameplay.CodeBase
{
  public class HistoryStep
  {
    private readonly GameState _state;
    private readonly (int row, int column) _cell;

    public HistoryStep(GameState state, (int row, int column) cell)
    {
      _state = state;
      _cell = cell;
    }

    public void Deconstruct(out GameState state, out (int row, int column) cell)
    {
      state = _state;
      cell = _cell;
    }
  }
}