using XO.Window.Windows;

namespace XO.Window
{
  public class WindowProvider : IWindowProvider
  {
    private readonly WindowsConfig _windowsConfig;

    public WindowProvider(WindowsConfig windowsConfig) => 
      _windowsConfig = windowsConfig;

    public BaseWindow GetWindow(WindowTypeId windowTypeId)
    {
      _windowsConfig.WindowsById.TryGetValue(windowTypeId, out BaseWindow window);
      return window;
    }
  }
}