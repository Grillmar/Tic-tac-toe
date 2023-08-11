using Zenject;

namespace XO.Modules.Window
{
  public static class WindowsServiceInstaller
  {
    public static DiContainer BindWindowProvider(this DiContainer container)
    {
      container.Bind<IWindowProvider>().To<WindowProvider>().AsSingle();

      return container;
    }
    
    public static DiContainer BindWindowService(this DiContainer container, WindowService windowService)
    {
      container.Bind<IWindowService>()
        .FromComponentInNewPrefab(windowService)
        .AsSingle()
        .NonLazy();

      return container;
    }
    
    public static DiContainer BindWindowConfig(this DiContainer container, WindowsConfig windowsConfig)
    {
      container.BindInstance(windowsConfig)
        .AsSingle()
        .NonLazy();
      
      return container;
    }
  }
}