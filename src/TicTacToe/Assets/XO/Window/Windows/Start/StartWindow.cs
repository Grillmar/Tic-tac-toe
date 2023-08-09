using System.Collections.Generic;
using UnityEngine.UI;
using XO.Gameplay.CodeBase;
using XO.Modules.Data;
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
    private GameData _gameData;

    [Inject]
    public void SetDependency(StateMachine stateMachine, IWindowService windowService, GameData gameData)
    {
      _stateMachine = stateMachine;
      _windowService = windowService;
      _gameData = gameData;
    }
    
    private void Awake()
    {
      Back.onClick.AddListener(CloseWindow);
      
      PlayerVsComputer.onClick.AddListener(PlayerVsComputerConfigure);
      PlayerVsPlayer.onClick.AddListener(PlayerVsPlayerConfigure);
      ComputerVsComputer.onClick.AddListener(ComputerVsComputerConfigure);
    }

    private void OnDestroy()
    {
      Back.onClick.RemoveListener(CloseWindow);
      
      PlayerVsComputer.onClick.RemoveListener(MoveToFight);
      PlayerVsPlayer.onClick.RemoveListener(MoveToFight);
      ComputerVsComputer.onClick.RemoveListener(MoveToFight);
    }

    private void PlayerVsComputerConfigure()
    {
      _gameData.Players = new List<IPlayer> { new RealPlayer(), new RandomComputerPlayer() };
      MoveToFight();
    }

    private void PlayerVsPlayerConfigure()
    {
      _gameData.Players = new List<IPlayer> { new RealPlayer(), new RealPlayer() };
      MoveToFight();
    }

    private void ComputerVsComputerConfigure()
    {
      _gameData.Players = new List<IPlayer> { new RandomComputerPlayer(), new RandomComputerPlayer() };
      MoveToFight();
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
