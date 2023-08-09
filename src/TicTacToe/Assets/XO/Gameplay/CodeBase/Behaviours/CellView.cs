using UnityEngine;
using UnityEngine.UI;
using XO.Extensions;

namespace XO.Gameplay.CodeBase.Behaviours
{
  public class CellView : MonoBehaviour
  {
    public Image View { get; private set; }

    public void Start() => 
      View = GetComponent<Image>();

    public void UpdateSprite(Sprite sprite, int alpha)
    {
      View.sprite = sprite;
      View.Alpha(alpha);
    }
  }
}