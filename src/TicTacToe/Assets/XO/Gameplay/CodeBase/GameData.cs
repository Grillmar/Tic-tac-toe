using System.Collections.Generic;
using XO.Gameplay.CodeBase.Player;

namespace XO.Gameplay.CodeBase
{
  public class GameData
  {
    public List<PlayerType> Players = new List<PlayerType> { PlayerType.RealPlayer, PlayerType.RealPlayer };

    public View View = new View();
  }
}