using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using XO.Modules.Window.Windows;
using Zenject;

namespace XO.Modules.Window
{
  public class WindowService : MonoBehaviour, IWindowService
  {
    public Transform WindowRoot;
    public event Action<WindowTypeId> OnClosed;

    private readonly List<BaseWindow> _openedWindows = new List<BaseWindow>();
    
    private IWindowProvider _provider;
    private DiContainer _container;

    [Inject]
    public void SetDependency(IWindowProvider provider, DiContainer container)
    {
      _provider = provider;

      _container = container;
    }

    public void Awake()
    {
      if (WindowRoot==null) 
        WindowRoot = transform;
    }

    public void Open(WindowTypeId windowTypeId)
    {
      if (IsOpened(windowTypeId))
      {
        Debug.LogError($"Window {windowTypeId} is already open");
        return;
      }

      BaseWindow windowPrefab = _provider.GetWindow(windowTypeId);
      _openedWindows.Add(_container.InstantiatePrefabForComponent<BaseWindow>(windowPrefab, WindowRoot));
    }

    public void Open<TPayload>(WindowTypeId windowTypeId, TPayload payLoad)
    {
      if (IsOpened(windowTypeId))
      {
        Debug.LogError($"Window {windowTypeId} is already open");
        return;
      }

      BaseWindow windowPrefab = _provider.GetWindow(windowTypeId);
      BaseWindow baseWindow = _container.InstantiatePrefabForComponent<BaseWindow>(windowPrefab, WindowRoot);
      _openedWindows.Add(baseWindow);

      if (baseWindow is PayloadedWindow<TPayload> window)
        window.Set(payLoad);
      else
        Debug.LogError($"Window {windowTypeId} is not a PayloadedWindow<{typeof(TPayload)}>");
    }

    public bool IsOpened(WindowTypeId windowTypeId) => 
      _openedWindows.Any(window => window.TypeId == windowTypeId);

    public void Close(WindowTypeId windowTypeId)
    {
      BaseWindow closingWindow = _openedWindows.First(x => x.TypeId == windowTypeId);
      closingWindow.Close();
      _openedWindows.Remove(closingWindow);
      OnClosed?.Invoke(windowTypeId);
    }

    public void CloseAll()
    {
      foreach (BaseWindow openedWindow in _openedWindows) 
        Close(openedWindow.TypeId);
    }
  }
}