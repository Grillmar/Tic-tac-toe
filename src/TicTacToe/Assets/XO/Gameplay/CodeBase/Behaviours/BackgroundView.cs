using UnityEngine;
using UnityEngine.UI;
using XO.Gameplay.CodeBase.Player;
using Zenject;

namespace XO.Gameplay.CodeBase.Behaviours
{
  public class BackgroundView : MonoBehaviour
  {
    public Image Image;
    private GameData _gameData;

    [Inject]
    public void SetDependency(Game game, GameData gameData)
    {
      _gameData = gameData;
    }

    private void Start() => 
      Image.sprite = _gameData.View.Background 
        ? _gameData.View.Background 
        : Image.sprite;
  }
}