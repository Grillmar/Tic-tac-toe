using UnityEngine.UI;
using XO.Modules.Machine;
using XO.Modules.States;
using Zenject;

namespace XO.Window.Windows.Start
{
  public class StartWindow : BaseWindow
  {
    
    public Button PlayerVsComputer;
    public Button PlayerVsPlayer;
    public Button ComputerVsComputer;
    
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
      
      PlayerVsComputer.onClick.AddListener(MoveToFight);
      PlayerVsPlayer.onClick.AddListener(MoveToFight);
      ComputerVsComputer.onClick.AddListener(MoveToFight);
    }

    private void OnDestroy()
    {
      Back.onClick.RemoveListener(CloseWindow);
      
      PlayerVsComputer.onClick.RemoveListener(MoveToFight);
      PlayerVsPlayer.onClick.RemoveListener(MoveToFight);
      ComputerVsComputer.onClick.RemoveListener(MoveToFight);
    }

    private void CloseWindow() => 
      _windowService.Close(TypeId);

    private void MoveToFight()
    {
      _stateMachine.Enter<LoadGameState>();
      _windowService.Close(TypeId);
    }
  }
}
