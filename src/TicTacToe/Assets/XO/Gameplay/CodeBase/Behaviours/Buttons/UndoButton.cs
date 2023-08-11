using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace XO.Gameplay.CodeBase.Behaviours.Buttons
{
  public class UndoButton : MonoBehaviour
  {
    public Button Button;
    
    private Game _game;

    [Inject]
    public void SetDependency(Game game) => 
      _game = game;

    public void Start() => 
      Button.onClick.AddListener(Undo);

    private void OnDestroy() => 
      Button.onClick.RemoveListener(Undo);
    
    private void Undo() => 
      _game.Undo();
  }
}