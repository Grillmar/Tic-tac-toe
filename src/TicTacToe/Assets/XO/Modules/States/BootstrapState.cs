using XO.Modules.Curtain;
using XO.Modules.Loader;
using XO.Modules.Machine;

namespace XO.Modules.States
{
  public class BootstrapState : IState
  {
    private const string Main = "MainScene";

    private readonly ISceneLoader _sceneLoader;
    private readonly StateMachine _stateMachine;
    private readonly LoadingCurtain _loadingCurtain;

    public BootstrapState(ISceneLoader sceneLoader, StateMachine stateMachine, LoadingCurtain loadingCurtain)
    {
      _sceneLoader = sceneLoader;
      _stateMachine = stateMachine;
      _loadingCurtain = loadingCurtain;
    }

    public void Enter()
    {
      _loadingCurtain.Show();
      Load();
    }

    public void Exit()
    {
    }

    private async void Load()
    {
      await _sceneLoader.LoadScene(Main);
      _stateMachine.Enter<MainState>();
    }
  }
}