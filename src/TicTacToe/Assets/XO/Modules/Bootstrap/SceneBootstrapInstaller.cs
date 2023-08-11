using XO.Modules.Window;
using Zenject;

namespace XO.Modules.Bootstrap
{
  public class SceneBootstrapInstaller : MonoInstaller
  {
    public WindowService WindowService;

    public override void InstallBindings()
    {
      Container.BindWindowService(WindowService);
    }
  }
}