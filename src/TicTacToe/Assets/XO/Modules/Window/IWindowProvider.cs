using XO.Modules.Window.Windows;

namespace XO.Modules.Window
{
  public interface IWindowProvider
  {
    BaseWindow GetWindow(WindowTypeId windowTypeId);
  }
}