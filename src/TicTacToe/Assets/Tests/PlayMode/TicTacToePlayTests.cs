using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using XO.Gameplay.CodeBase;
using XO.Gameplay.CodeBase.Behaviours.Buttons;
using XO.Gameplay.CodeBase.Player;
using XO.Modules.CustomYieldI;
using XO.Modules.Machine;
using XO.Modules.States;
using XO.Modules.Window;
using XO.Modules.Window.Windows;
using XO.Modules.Window.Windows.End;
using Zenject;

namespace Tests.PlayMode
{
  public class TicTacToePlayTests
  {
    private const string MainScene = "MainScene";
    private const string GameScene = "GameScene";
    
    private StateMachine _stateMachine;
    private GameData _gameData;
    private IWindowService _windowService;

    [Inject]
    public void SetDependency(StateMachine stateMachine, GameData gameData)
    {
      _stateMachine = stateMachine;
      _gameData = gameData;
    }

    [OneTimeSetUp]
    public void OneDerivedSetUp() => 
      ProjectContext.Instance.Container.Inject(this);

    [UnityTest]
    public IEnumerator TouchHintButtonThenStartedBlinkCoroutine()
    {
      yield return new WaitForSceneLoaded(MainScene);
      
      _gameData.Players = new List<PlayerType>
      {
        PlayerType.RealPlayer, 
        PlayerType.EasyComputer
      };
      
      _stateMachine.Enter<LoadGameState>();

      yield return new WaitForSceneLoaded(GameScene);
      yield return new WaitForSeconds(1);

      HintButton hintButton = GetComponents<HintButton>(SceneManager.GetActiveScene()).First();
     
      System.Type hintButtonType = hintButton.GetType();
      FieldInfo blinkCoroutineField = hintButtonType.GetField("_blinkCoroutine", BindingFlags.NonPublic | BindingFlags.Instance);

      hintButton.Button.onClick.Invoke();
      
      yield return new WaitForSeconds(1);
        
      var blinkCoroutine = (Coroutine)blinkCoroutineField?.GetValue(hintButton);

      blinkCoroutine.Should().NotBeNull();
    }

    [UnityTest]
    public IEnumerator After5SecondGameActivePlayerLose()
    {
      yield return new WaitForSceneLoaded(MainScene);
      
      _gameData.Players = new List<PlayerType>
      {
        PlayerType.RealPlayer, 
        PlayerType.RealPlayer
      };
      
      _stateMachine.Enter<LoadGameState>();

      yield return new WaitForSceneLoaded(GameScene);
      yield return new WaitForSeconds(7);

      EndWindow endWindow = GetComponents<EndWindow>(SceneManager.GetActiveScene()).First();
      
      endWindow.TypeId.Should().Be(WindowTypeId.Lose);
    }
    
    private static List<T> GetComponents<T>(Scene openedScene)
    {
      var stageDialogControllers = new List<T>();
      foreach (GameObject rootGameObject in openedScene.GetRootGameObjects())
        stageDialogControllers.AddRange(rootGameObject.GetComponentsInChildren<T>(true));
      return stageDialogControllers;
    }
  }
}