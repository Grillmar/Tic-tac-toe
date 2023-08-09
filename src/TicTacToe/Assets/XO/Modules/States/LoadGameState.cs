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

    public LoadGameState(LoadingCurtain loadingCurtain, StateMachine stateMachine, ISceneLoader sceneLoader)
    {
      _loadingCurtain = loadingCurtain;
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
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
      await _sceneLoader.LoadScene(GameScene);
      _stateMachine.Enter<GameLoop>();
    }
  }
}