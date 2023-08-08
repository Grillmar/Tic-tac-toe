namespace XO.Game.CodeBase
{
  internal class HistoryStep
  {
    private readonly GameState _state;
    private readonly Symbol _symbol;
    private readonly Cell _cell;

    public HistoryStep(GameState state, Symbol symbol, Cell cell)
    {
      _state = state;
      _symbol = symbol;
      _cell = cell;
    }

    public void Deconstruct(out GameState state, out Symbol symbol, out Cell cell)
    {
      state = _state;
      symbol = _symbol;
      cell = _cell;
    }
  }
}