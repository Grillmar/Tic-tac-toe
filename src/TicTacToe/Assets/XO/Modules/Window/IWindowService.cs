using System;
using XO.Modules.Window.Windows;

namespace XO.Modules.Window
{
  public interface IWindowService
  {
    void Open(WindowTypeId windowTypeId);

    void Open<TPayLoad>(WindowTypeId windowTypeId, TPayLoad payLoad);

    bool IsOpened(WindowTypeId windowTypeId);

    void Close(WindowTypeId windowTypeId);

    void CloseAll();

    event Action<WindowTypeId> OnClosed;
  }
}