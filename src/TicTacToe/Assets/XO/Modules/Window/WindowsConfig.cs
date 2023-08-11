using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using XO.Modules.Window.Windows;

namespace XO.Modules.Window
{
  [CreateAssetMenu(menuName = "Configs/Windows")]
  public class WindowsConfig : SerializedScriptableObject
  {
    public Dictionary<WindowTypeId, BaseWindow> WindowsById;
  }
}