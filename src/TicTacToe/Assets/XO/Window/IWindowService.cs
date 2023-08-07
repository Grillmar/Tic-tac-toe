using System;
using XO.Window.Windows;

namespace XO.Window
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