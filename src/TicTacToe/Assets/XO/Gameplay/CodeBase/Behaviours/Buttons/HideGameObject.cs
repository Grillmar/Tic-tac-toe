using System.Linq;
using UnityEngine;
using XO.Gameplay.CodeBase.Player;
using Zenject;

namespace XO.Gameplay.CodeBase.Behaviours.Buttons
{
  public class HideGameObject : MonoBehaviour
  {
    public GameObject GameObject;
    
    private GameData _gameData;

    [Inject]
    public void SetDependency(GameData gameData) =>
      _gameData = gameData;

    private void Start() => 
      GameObject.SetActive(IsPlayerVsComputer());

    private bool IsPlayerVsComputer() => 
      _gameData.Players.Any(x=> x == PlayerType.RealPlayer) 
      && _gameData.Players.Any(x=> x != PlayerType.RealPlayer);
  }
}