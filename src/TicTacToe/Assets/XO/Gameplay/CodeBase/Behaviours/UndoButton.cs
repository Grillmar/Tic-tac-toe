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
      
      if (_gameLoop.IsInitialized)
        _game = _gameLoop.Game;
      else
        _gameLoop.OnInitialize += () => { _game = _gameLoop.Game; };
    }
    
    private void OnDestroy() => 
      Button.onClick.RemoveListener(Undo);

    private void Undo() => 
      _game.Undo();
  }
}