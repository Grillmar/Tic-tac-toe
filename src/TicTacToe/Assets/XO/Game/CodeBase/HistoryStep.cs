namespace XO.Game.CodeBase
{
  internal class HistoryStep
  {
    private readonly GameState _state;
    private readonly Symbol _playerSymbol;
    private readonly Cell _cell;

    public HistoryStep(GameState state, Symbol playerSymbol, Cell cell)
    {
      _state = state;
      _playerSymbol = playerSymbol;
      _cell = cell;
    }
  }
}