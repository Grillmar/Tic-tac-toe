using XO.Window.Windows;

namespace XO.Window
{
  public interface IWindowProvider
  {
    BaseWindow GetWindow(WindowTypeId windowTypeId);
  }
}