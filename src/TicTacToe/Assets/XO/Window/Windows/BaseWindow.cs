using UnityEngine;

namespace XO.Window.Windows
{
  public class BaseWindow : MonoBehaviour
  {
    [SerializeField]
    private WindowTypeId _typeId = WindowTypeId.None;

    public WindowTypeId TypeId => _typeId;

    public virtual void Close() => 
      Destroy(gameObject);
  }
}