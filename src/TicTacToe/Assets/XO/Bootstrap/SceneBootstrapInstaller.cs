using XO.Window;
using Zenject;

namespace XO.Bootstrap
{
  public class SceneBootstrapInstaller : MonoInstaller
  {
    public WindowService WindowService;

    public override void InstallBindings()
    {
      Container
        .BindWindowService(WindowService);
    }
  }
}