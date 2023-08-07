using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using XO.Window.Windows;

namespace XO.Window
{
  [CreateAssetMenu(menuName = "Configs/Windows")]
  public class WindowsConfig : SerializedScriptableObject
  {
    public Dictionary<WindowTypeId, BaseWindow> WindowsById;
  }
}