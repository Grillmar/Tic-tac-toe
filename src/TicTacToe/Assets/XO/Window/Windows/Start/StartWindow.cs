using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using XO.Extensions;
using XO.Modules.Data;
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
    private GameData _gameData;

    private Player _difficult;

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
      _gameData.Players = new List<Player>
      {
        Player.RealPlayer,
        GetComputer()
      };
      _gameData.Players.Shuffle();
      MoveToFight();
    }

    private void PlayerVsPlayerConfigure()
    {
      _gameData.Players = new List<Player>
      {
        Player.RealPlayer, 
        Player.RealPlayer
      };
      MoveToFight();
    }

    private void ComputerVsComputerConfigure()
    {
      _gameData.Players = new List<Player>
      {
        GetRandomComputer(),
        GetRandomComputer()
      };
      MoveToFight();
    }

    private Player GetComputer() => 
      _difficult;

    private void ChangeDifficult(int difficult) => 
      _difficult = (Player)difficult;

    private Player GetRandomComputer() => 
      new[] { Player.EasyComputer, Player.NormalComputer, Player.HardComputer }
        .RandomElement();
  }
}
