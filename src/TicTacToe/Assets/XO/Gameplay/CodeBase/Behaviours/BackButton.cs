using UnityEngine;
using UnityEngine.UI;
using XO.Modules.Machine;
using XO.Modules.States;
using Zenject;

namespace XO.Gameplay.CodeBase.Behaviours
{
  public class BackButton : MonoBehaviour
  {
    public Button Button;
    private StateMachine _stateMachine;
    
    [Inject]
    public void SetDependency(StateMachine stateMachine) => 
      _stateMachine = stateMachine;

    private void Start() => 
      Button.onClick.AddListener(Back);

    private void OnDestroy() => 
      Button.onClick.RemoveListener(Back);

    private void Back() => 
      _stateMachine.Enter<LoadMainState>();
  }
}