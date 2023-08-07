using XO.Modules.Curtain;
using XO.Modules.Loader;
using XO.Modules.Machine;

namespace XO.Modules.States
{
  public class LoadGameState : IPayloadState<string>
  {
    private readonly LoadingCurtain _loadingCurtain;
    private readonly StateMachine _stateMachine;
    private readonly ISceneLoader _sceneLoader;

    public LoadGameState(LoadingCurtain loadingCurtain, StateMachine stateMachine, ISceneLoader sceneLoader)
    {
      _loadingCurtain = loadingCurtain;
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
    }

    public void Enter(string sceneName)
    {
      _loadingCurtain.Show();
      
      Load(sceneName);
    }

    public void Exit()
    {
      _loadingCurtain.Hide();
    }

    private async void Load(string sceneName)
    {
      await _sceneLoader.LoadScene(sceneName);
      _stateMachine.Enter<GameState>();
    }
  }
  
  
  
}