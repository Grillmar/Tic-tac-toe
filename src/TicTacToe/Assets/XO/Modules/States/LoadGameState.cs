using XO.Gameplay.CodeBase;
using XO.Gameplay.CodeBase.Player;
using XO.Modules.AssetsManagement;
using XO.Modules.Curtain;
using XO.Modules.Loader;
using XO.Modules.Machine;

namespace XO.Modules.States
{
  public class LoadGameState : IState
  {
    private const string GameScene = "GameScene";

    
    private readonly LoadingCurtain _loadingCurtain;
    private readonly StateMachine _stateMachine;
    private readonly ISceneLoader _sceneLoader;
    private readonly GameData _gameData;
    private readonly IAssetProvider _assetProvider;
    public LoadGameState(
      LoadingCurtain loadingCurtain,
      StateMachine stateMachine,
      ISceneLoader sceneLoader,
      GameData gameData,
      IAssetProvider assetProvider)
    {
      _loadingCurtain = loadingCurtain;
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
      _gameData = gameData;
      _assetProvider = assetProvider;

    }

    public void Enter()
    {
      _loadingCurtain.Show();

      Load();
    }

    public void Exit()
    {
      _loadingCurtain.Hide();
    }

    private async void Load()
    {
      _gameData.View = new View
      {
        Background = await _assetProvider.LoadSprites("Background"),
        X = await _assetProvider.LoadSprites("X"),
        O = await _assetProvider.LoadSprites("O"),
      };
      
      await _sceneLoader.LoadScene(GameScene);
      _stateMachine.Enter<GameLoop>();
    }
  }
}