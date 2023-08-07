using UnityEngine.UI;
using XO.Modules.Machine;
using XO.Modules.States;
using Zenject;

namespace XO.Window.Windows.Start
{
  public class StartWindow : BaseWindow
  {
    private const string GameScene = "GameScene";
    
    public Button Game;
    public Button Back;

    private StateMachine _stateMachine;
    private IWindowService _windowService;

    [Inject]
    public void SetDependency(StateMachine stateMachine, IWindowService windowService)
    {
      _stateMachine = stateMachine;
      _windowService = windowService;
    }
    
    private void Awake()
    {
      Back.onClick.AddListener(CloseWindow);
      Game.onClick.AddListener(MoveToFight);
    }

    private void OnDestroy()
    {
      Back.onClick.RemoveListener(CloseWindow);
      Game.onClick.RemoveListener(MoveToFight);
    }

    private void CloseWindow() => 
      _windowService.Close(TypeId);

    private void MoveToFight()
    {
      _stateMachine.Enter<LoadGameState, string>(GameScene);
      _windowService.Close(TypeId);
    }
  }
}
