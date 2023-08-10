using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using XO.Extensions;
using XO.Gameplay.CodeBase.Player;
using XO.Modules.Machine;
using XO.Modules.States;
using Zenject;

namespace XO.Window.Windows.Start
{
  public class StartWindow : BaseWindow
  {
    public TMP_Dropdown Difficult;
    
    public Button PlayerVsComputer;
    public Button PlayerVsPlayer;
    public Button ComputerVsComputer;
    
    public Button Back;

    private StateMachine _stateMachine;
    private IWindowService _windowService;
    private PlayerData _playerData;

    private PlayerType _difficult;

    [Inject]
    public void SetDependency(StateMachine stateMachine, IWindowService windowService, PlayerData playerData)
    {
      _stateMachine = stateMachine;
      _windowService = windowService;
      _playerData = playerData;
    }
    
    private void Awake()
    {
      Back.onClick.AddListener(CloseWindow);
      
      PlayerVsComputer.onClick.AddListener(PlayerVsComputerConfigure);
      PlayerVsPlayer.onClick.AddListener(PlayerVsPlayerConfigure);
      ComputerVsComputer.onClick.AddListener(ComputerVsComputerConfigure);
      
      Difficult.onValueChanged.AddListener(ChangeDifficult);
    }

    private void OnDestroy()
    {
      Back.onClick.RemoveListener(CloseWindow);
      
      PlayerVsComputer.onClick.RemoveListener(PlayerVsComputerConfigure);
      PlayerVsPlayer.onClick.RemoveListener(PlayerVsPlayerConfigure);
      ComputerVsComputer.onClick.RemoveListener(ComputerVsComputerConfigure);
      
      Difficult.onValueChanged.RemoveListener(ChangeDifficult);
    }
    private void CloseWindow() => 
      _windowService.Close(TypeId);

    private void MoveToFight()
    {
      _stateMachine.Enter<LoadGameState>();
      _windowService.Close(TypeId);
    }
    private void PlayerVsComputerConfigure()
    {
      _playerData.Players = new List<PlayerType>
      {
        PlayerType.RealPlayer,
        GetComputer()
      };
      _playerData.Players.Shuffle();
      MoveToFight();
    }

    private void PlayerVsPlayerConfigure()
    {
      _playerData.Players = new List<PlayerType>
      {
        PlayerType.RealPlayer, 
        PlayerType.RealPlayer
      };
      MoveToFight();
    }

    private void ComputerVsComputerConfigure()
    {
      _playerData.Players = new List<PlayerType>
      {
        GetRandomComputer(),
        GetRandomComputer()
      };
      MoveToFight();
    }

    private PlayerType GetComputer() => 
      _difficult;

    private void ChangeDifficult(int difficult) => 
      _difficult = (PlayerType)difficult;

    private PlayerType GetRandomComputer() => 
      new[] { PlayerType.EasyComputer, PlayerType.NormalComputer, PlayerType.HardComputer }
        .RandomElement();
  }
}
