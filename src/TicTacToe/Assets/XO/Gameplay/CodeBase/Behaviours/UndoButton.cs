using UnityEngine;
using UnityEngine.UI;
using XO.Modules.States;
using Zenject;

namespace XO.Gameplay.CodeBase.Behaviours
{
  public class UndoButton : MonoBehaviour
  {
    public Button Button;
    
    private GameLoop _gameLoop;
    private Game _game;

    [Inject]
    public void SetDependency(GameLoop gameLoop) => 
      _gameLoop = gameLoop;

    public void Start()
    {
      Button.onClick.AddListener(Undo);
      
      _gameLoop.OnInitialize += SubscribeOnInitialize;
    }

    private void OnDestroy()
    {
      _gameLoop.OnInitialize -= SubscribeOnInitialize;
      Button.onClick.RemoveListener(Undo);
    }

    private void SubscribeOnInitialize() => 
      _game = _gameLoop.Game;

    private void Undo() => 
      _game.Undo();
  }
}