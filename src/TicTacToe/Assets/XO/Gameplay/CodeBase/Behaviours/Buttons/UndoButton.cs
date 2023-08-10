using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace XO.Gameplay.CodeBase.Behaviours.Buttons
{
  public class UndoButton : MonoBehaviour
  {
    public Button Button;
    
    private Game _gameLoop;

    [Inject]
    public void SetDependency(Game gameLoop) => 
      _gameLoop = gameLoop;

    public void Start() => 
      Button.onClick.AddListener(Undo);

    private void OnDestroy() => 
      Button.onClick.RemoveListener(Undo);
    
    private void Undo() => 
      _gameLoop.Undo();
  }
}