using UnityEngine;
using UnityEngine.UI;

namespace XO.Gameplay.CodeBase.Behaviours
{
  public class CellView : MonoBehaviour
  {
    public Image View { get; private set; }
    
    public void Start() => 
      View = GetComponent<Image>();
  }
}