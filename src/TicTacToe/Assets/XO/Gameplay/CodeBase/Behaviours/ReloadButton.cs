using UnityEngine;
using UnityEngine.UI;
using XO.Modules.Machine;
using XO.Modules.States;
using Zenject;

namespace XO.Gameplay.CodeBase.Behaviours
{
  public class ReloadButton : MonoBehaviour
  {
    public Button Button;
    
    private StateMachine _stateMachine;
    
    [Inject]
    public void SetDependency(StateMachine stateMachine) => 
      _stateMachine = stateMachine;

    private void Start() => 
      Button.onClick.AddListener(Reload);

    private void OnDestroy() => 
      Button.onClick.RemoveListener(Reload);

    private void Reload() => 
      _stateMachine.Enter<LoadGameState>();
  }
}